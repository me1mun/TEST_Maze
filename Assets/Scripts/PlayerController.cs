using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public const float speed = 5f;
    private const float rotationSpeed = 720f;
    private CharacterController characterController;
    private Vector3 lookDirection;
    [SerializeField] private GameplayInput gameplayInput;
    private Animator animator;

    private bool isMoving;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector2 input = gameplayInput.GetMovementInput();

        if (input.magnitude > 0)
        {
            if (isMoving == false)
            {
                isMoving = true;
                animator.SetTrigger("Run");
            }
            
            Vector3 direction = new Vector3(input.x, 0, input.y);
            direction.Normalize();
            Move(direction);

            lookDirection = direction;
        }
        else
        {
            if (isMoving == true)
            {
                isMoving = false;
                animator.SetTrigger("Idle");
            }
        }        

        Rotate();
    }

    private void Move(Vector3 direction)
    {
        Vector3 move = direction * speed * Time.deltaTime;
        characterController.Move(move);
    }

    private void Rotate()
    {
        if (lookDirection != Vector3.zero)
        {
            float angleDifference = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(lookDirection));

            if (angleDifference > 1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void CollectKey(Key key)
    {
        key.gameObject.SetActive(false);

        GameplayController.Instance.CollectKey();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Key"))
        {
            Key key = other.GetComponent<Key>();
            if (key)
            {
                CollectKey(key);
            }
        }
        
        if (other.CompareTag("Portal"))
        {
            PortalController portalController = other.GetComponent<PortalController>();
            if (portalController && portalController.isUnlocked)
            {
                GameplayController.Instance.RestartLevel();
            }
        }
    }
}
