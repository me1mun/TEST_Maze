using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInput : MonoBehaviour
{
    public Vector2 GetMovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        return new Vector2(horizontal, vertical);
    }
}
