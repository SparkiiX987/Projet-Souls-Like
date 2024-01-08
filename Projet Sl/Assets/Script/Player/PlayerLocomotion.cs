using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour
{
    #region PlayerRef
        Vector3 moveDirection;
        private new Rigidbody rb;
        private PlayerStats stats;

        [HideInInspector]
        public Transform myTransform;

        [Header("Stats")]
        [SerializeField] float movementSpeed = 5;
        [SerializeField] float sprintSpeed = 8;
        [SerializeField] float jumpHeight = 8;
        [SerializeField] float dodgeDistance = 10;
        private Vector3 lastMoveDirection;

        [Header("Collisions Detection")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;


        [Header("Bool Check")]
        public bool isGrounded;
        public bool isSprinting;
        public bool isDodging;
    #endregion

    #region InputList
        public InputAction moveAction;
        public InputAction sprintAction;
        public InputAction jumpAction;
        public InputAction dodgeAction;
    #endregion

    #region Camera
        public GameObject cameraObject;
        public float mouseSensitivity = 2f;
        float cameraVerticalRotation = 0f;
    #endregion

    private void OnEnable()
    {
        moveAction.Enable();
        sprintAction.Enable();
        jumpAction.Enable();
        dodgeAction.Enable();

        jumpAction.performed += _ => Jump();
        dodgeAction.performed += _ => Dodge();

        sprintAction.started += _ => StartSprint();
        sprintAction.canceled += _ => StopSprint();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        sprintAction.Disable();
        jumpAction.Disable();
        dodgeAction.Disable();
    }


    void Start()
    {
        stats = GetComponent<PlayerStats>();
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

            Vector3 movement;

            if (isSprinting)
            {
                movement = moveDirection * sprintSpeed * Time.deltaTime;
            }
            else
            {
                movement = moveDirection * movementSpeed * Time.deltaTime;
            }

            rb.MovePosition(transform.position + movement);
        }

        lastMoveDirection = moveDirection;
    }

    public void StartSprint()
    {
        if (!stats.noStamina)
        {
            isSprinting = true;
            StartCoroutine(stats.DrainStamina());
            StopCoroutine(stats.RegenStamina());
        }
    }

    public void StopSprint()
    {
        isSprinting = false;
        StopCoroutine(stats.DrainStamina());
        StartCoroutine(stats.RegenStamina());
    }

    public void Jump()
    {
        if (isGrounded && !stats.noStamina)
        {
            float jumpForce = Mathf.Sqrt(3f * jumpHeight * -Physics.gravity.y);
            rb.AddForce((Vector3.up + lastMoveDirection) * jumpForce, ForceMode.Impulse);
            stats.stamina -= 10;
            isGrounded = false;
        }
    }

    public void Dodge()
    {
        if (!isDodging && isGrounded && !stats.noStamina)
        {
            Vector3 dodgeVelocity = transform.forward * dodgeDistance;
            rb.AddForce(dodgeVelocity, ForceMode.VelocityChange);
            isDodging = true;
            StartCoroutine(StopDodging());
            stats.stamina -= 20;
        }
    }

    IEnumerator StopDodging()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector3.zero;
        isDodging = false;
    }

    public void GroundCheck()
    {
        Collider[] colliders = Physics.OverlapBox(groundCheck.position, Vector3.one * 0.5f, Quaternion.identity, groundLayer);
        bool wasGrounded = isGrounded;
        isGrounded = colliders.Length > 0;

        if (!wasGrounded && isGrounded)
        {
            rb.velocity = Vector3.zero; 
        }
    }
}
