using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public float speed;
    public float mouseX;
    public float mouseY;

    PlayerController inputActions;

    Vector2 movementInput;
    Vector2 cameraInput;

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerController();
            inputActions.PlayerMovements.Movements.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovements.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }
}
