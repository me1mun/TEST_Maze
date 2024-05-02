using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController Instance { get; private set; }

    [SerializeField] private UIController uiController;

    [SerializeField] private PlayerController player;
    [SerializeField] private PortalController portal;

    [SerializeField] private Transform keysHolder;
    public int totalKeys { get; private set; }
    public int collectedKeys { get; private set; }

    private float gameTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        InitializeKeyCount();
        uiController.InitializeKeyBar(totalKeys);
    }

    private void InitializeKeyCount()
    {
        totalKeys = keysHolder.childCount;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        uiController.UpdateGameTime(gameTime);
    }

    public void CollectKey()
    {
        if (collectedKeys < totalKeys)
        {
            collectedKeys++;
            uiController.UpdateKeyBar(collectedKeys);

            
        }

        if (collectedKeys >= totalKeys)
        {
            UnlockExit();
        }
    }

    private void UnlockExit()
    {
        portal.Activate();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
