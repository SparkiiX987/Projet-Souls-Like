using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour
{
    #region PlayerRef
        Vector3 moveDirection;
        private new Rigidbody rb;

    [HideInInspector]
        public Transform myTransform;

        [Header("Stats")]
        [SerializeField] float movementSpeed = 5;
        [SerializeField] float jumpHeight = 10;
        [SerializeField] float dodgeDistance = 10;

        [Header("Collisions Detection")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        public bool isGrounded;
        private Vector3 lastMoveDirection;
        public bool isSprinting;
        public bool isDodging;
    #endregion

    #region InputList
        public InputAction moveAction;
        public InputAction jumpAction;
        public InputAction dodgeAction;
    #endregion

    #region Camera
    public GameObject cameraObject;
        public float mouseSensitivity = 2f;
        float cameraVerticalRotation = 0f;
        bool lockedCursor = true;
    #endregion

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();

        jumpAction.performed += _ => Jump();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }


    void Start()
    {
        myTransform = transform;
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleRotation();
        HandleMovement();
        GroundCheck();
    }

    public void HandleRotation()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation -= inputY;

        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        cameraObject.transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        transform.Rotate(Vector3.up * inputX);
    }

    public void HandleMovement()
    {
        if (isGrounded)
        {
            Vector2 movementInput = moveAction.ReadValue<Vector2>();
            float inputX = movementInput.x;
            float inputZ = movementInput.y;

            moveDirection = (transform.right * inputX + transform.forward * inputZ).normalized;

            Vector3 movement = moveDirection * movementSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }

        lastMoveDirection = moveDirection;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            float jumpForce = Mathf.Sqrt(2f * jumpHeight * -Physics.gravity.y);
            rb.AddForce((Vector3.up + lastMoveDirection) * jumpForce / 1.5f, ForceMode.VelocityChange);
        }
    }

    public void Dodge()
    {
        
    }

    public void GroundCheck()
    {
        Collider[] colliders = Physics.OverlapBox(groundCheck.position, Vector3.one * 0.5f, Quaternion.identity, groundLayer);
        isGrounded = colliders.Length > 0;
    }
}
