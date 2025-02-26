using UnityEngine;

public class GlideMovement : MonoBehaviour
{
    [Header("Ground Movement")]
    public float moveSpeed = 10f; // Walking speed
    public float jumpForce = 12f; // Stronger jump for a better leap
    public float leapForwardForce = 5f; // Forward push when jumping
    public float groundCheckDistance = 1.1f; // Ground detection

    [Header("Gliding Mechanics")]
    public float glideFallSpeed = 0.5f; // Slow descent when gliding
    public float glideForwardBoost = 3f; // Forward momentum while gliding
    public float maxGlideTime = 8f; // Increase glide duration
    public float glideControlSpeed = 6f; // Steering left/right while gliding
    public float airTurnSpeed = 75f; // Turning speed while in air

    [Header("Rotation Settings")]
    public float groundTurnSpeed = 100f; // How fast player rotates on the ground

    private Rigidbody rb;
    private bool isGliding = false;
    private float glideTimer;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the player!");
        }

        rb.freezeRotation = true; // Prevent physics from rotating the character
    }

    void Update()
    {
        CheckGrounded();
        MovePlayer();
        RotatePlayer(); // Full 360 rotation on ground and air

        if (Input.GetKeyDown(KeyCode.Space)) // Press Space once to jump & glide
        {
            LeapAndStartGlide();
        }

        if (isGrounded) // Stop gliding when landing
        {
            StopGlide();
        }
    }

    void FixedUpdate()
    {
        if (isGliding)
        {
            Glide();
        }
    }

    void MovePlayer()
    {
        float moveZ = Input.GetAxisRaw("Vertical"); // W & S for forward/backward

        // Move forward/backward based on player rotation
        Vector3 moveDirection = transform.forward * moveZ;

        if (moveZ != 0)
        {
            rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0); // STOP movement immediately when key is released
        }

        // STOP GLIDING if no forward movement
        if (moveZ == 0 && isGliding)
        {
            StopGlide();
        }
    }

    void RotatePlayer()
    {
        float turnInput = Input.GetAxisRaw("Horizontal"); // Get A/D input

        if (turnInput != 0)
        {
            // Rotate on the ground and in the air
            float turnSpeed = isGliding ? airTurnSpeed : groundTurnSpeed;
            transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        }
    }

    void LeapAndStartGlide()
    {
        if (isGrounded)
        {
            // Add a forward force for a LEAP effect
            Vector3 leapDirection = transform.forward * leapForwardForce;
            rb.velocity = new Vector3(leapDirection.x, jumpForce, leapDirection.z);
        }
        StartGlide(); // Automatically start gliding after jumping
    }

    void StartGlide()
    {
        isGliding = true;
        rb.useGravity = false; // Remove default gravity
        glideTimer = maxGlideTime;
    }

    void Glide()
    {
        if (glideTimer > 0)
        {
            // Slow falling effect while gliding
            rb.velocity = new Vector3(rb.velocity.x, -glideFallSpeed, rb.velocity.z);

            // Move forward in the direction the player is facing
            rb.velocity += transform.forward * glideForwardBoost * Time.deltaTime;

            // FIXED: Left and Right Gliding Movement Now Exactly the Same
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            if (horizontalInput < 0) // Moving Left
            {
                rb.velocity += -transform.right * Mathf.Abs(horizontalInput) * glideControlSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up * horizontalInput * airTurnSpeed * Time.deltaTime);
            }
            else if (horizontalInput > 0) // Moving Right
            {
                rb.velocity += transform.right * horizontalInput * glideControlSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up * horizontalInput * airTurnSpeed * Time.deltaTime);
            }

            glideTimer -= Time.deltaTime;
        }
        else
        {
            StopGlide();
        }
    }

    void StopGlide()
    {
        isGliding = false;
        rb.useGravity = true;
    }

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }
}
