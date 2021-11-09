using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Controls controls;
    CharacterController controller;

    [Header("Speed")]
    public float normalSpeed;
    public float runningSpeed;

    [Space]
    [Header("Gravity")]
    public Transform groundCheck;
    public float gravity = -9.81f;
    public float groundRadius = 0.4f;
    public LayerMask groundMask;

    [Space]
    public float jumpHeight = 1.5f;

    //Private Variables
    float currentSpeed;

    //Gravity
    bool isGrounded;
    Vector3 velocity;


    #region Input System
    private void Awake()
    {

        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public Vector2 getPlayerMovement()
    {
        return controls.Player.Movement.ReadValue<Vector2>();
    }

    public bool playerJumpThisFrame()
    {
        return controls.Player.Jump.triggered;
    }
    #endregion
    void Start()
    {
        controller = GetComponent<CharacterController>();

        currentSpeed = normalSpeed;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        move();
        physics();
        controller.Move(velocity * Time.deltaTime);
    }

    void move()
    {
        Vector2 movement = getPlayerMovement();

        Vector3 move = transform.right * movement.x + transform.forward * movement.y;
        controller.Move(move.normalized * currentSpeed * Time.deltaTime);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isRunning)
        {
            currentSpeed = runningSpeed;
        }
        else if (!isRunning)
        {
            currentSpeed = normalSpeed;
        }
    }

    void physics()
    {
        bool isJumping = playerJumpThisFrame();

        if (isJumping && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
