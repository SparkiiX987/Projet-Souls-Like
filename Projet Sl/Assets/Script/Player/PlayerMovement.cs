using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private InputAction playerMovement;
    //[SerializeField] private InputAction playerAttack;
    //[SerializeField] private InputAction playerInteract;

    private Vector3 moveDirection = Vector3.zero;

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        

        moveDirection = new Vector3(playerMovement.ReadValue<Vector2>().x, 0f, playerMovement.ReadValue<Vector2>().y);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * speed, moveDirection.y * speed, moveDirection.z * speed);
    }
}
