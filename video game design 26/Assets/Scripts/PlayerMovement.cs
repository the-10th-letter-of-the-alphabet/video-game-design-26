using UnityEngine;
using UnityEngine.InputSystem;

namespace player {
public class PlayerMovement : MonoBehaviour
{
    
    [Header("Movement")]
    [SerializeField] private float moveAcceleration = 100f;
    [SerializeField] private float maxSpeed = 50f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpCooldown = 0.25f;
    [SerializeField] private float airMultiplier = 0.4f;

    public bool readyToJump = true;

    public bool isGrounded = false;

    [Header("Ground Check")]
    [SerializeField] private float playerHeight = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDrag = 10f;

    [SerializeField] private float rotationSpeed = 3000f;
    
    private Rigidbody rb;

    void OnEnable()
    {
        InputSystem.actions.FindAction("Move").Enable();
        InputSystem.actions.FindAction("Jump").Enable();
    }

    void OnDisable()
    {
        InputSystem.actions.FindAction("Move").Disable();
        InputSystem.actions.FindAction("Jump").Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        if (isGrounded){
            rb.linearDamping = groundDrag;
        } else {
            rb.linearDamping = 0.25f;
        }
        JumpInput();
    }

    void FixedUpdate()
    {
        MoveAndRotatePlayer();
        SpeedControl();
    }
    void MoveAndRotatePlayer(){
        Vector2 moveDirection = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);
        if (isGrounded){
            rb.AddForce(move * moveAcceleration, ForceMode.Acceleration);
        } else {
            rb.AddForce(move * moveAcceleration * airMultiplier, ForceMode.Acceleration);
        }
        
        if (moveDirection.magnitude != 0) {
            Quaternion targetRotation = Quaternion.LookRotation(rb.linearVelocity + Vector3.back * 0.01f);
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
        }
    }

    private void SpeedControl(){
        if (rb.linearVelocity.magnitude > maxSpeed){
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    private void Jump(){
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void JumpInput(){
        if (InputSystem.actions.FindAction("Jump").ReadValue<float>() > 0 && readyToJump && isGrounded){
            Jump();
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void ResetJump(){
        readyToJump = true;
    }
}
}

