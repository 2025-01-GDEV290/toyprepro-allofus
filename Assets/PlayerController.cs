using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody rb; // Reference to Rigidbody

    [Header("Inventory & Feeding")]
    private int appleCount = 0; // Tracks collected apples
    public Transform snowman;   // Assign Snowman in Inspector
    public float feedRange = 2f;  // Distance within which the snowman eats an apple

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component
        rb.freezeRotation = true; // Prevent unwanted physics rotation
    }

    void Update()
    {
        MovePlayer();
        CheckFeedSnowman();
    }

    void MovePlayer()
    {
        // Get input for movement (W = Forward, S = Backward, A = Left, D = Right)
        float moveZ = 0f; // Forward / Backward
        float moveX = 0f; // Left / Right

        if (Input.GetKey(KeyCode.D)) moveZ = 1f;  // Move forward
        if (Input.GetKey(KeyCode.A)) moveZ = -1f; // Move backward
        if (Input.GetKey(KeyCode.W)) moveX = -1f; // Move left
        if (Input.GetKey(KeyCode.S)) moveX = 1f;  // Move right

        // Convert input into movement direction **relative to the player's forward direction**
        Vector3 moveDirection = (transform.forward * moveZ) + (transform.right * moveX);
        moveDirection.Normalize(); // Prevent diagonal movement from being faster

        // Apply movement using Rigidbody velocity
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        // Picking up Apples
        if (other.CompareTag("Apple"))
        {
            appleCount++; // Increase apple count
            Destroy(other.gameObject); // Remove apple from the scene
            Debug.Log("Picked up an apple! Total Apples: " + appleCount);
        }
    }

    void CheckFeedSnowman()
    {
        float distance = Vector3.Distance(transform.position, snowman.position);

        if (appleCount > 0 && distance <= feedRange)
        {
            appleCount--; // Remove apple from inventory
            Debug.Log("Snowman ate an apple! Remaining Apples: " + appleCount);
        }
    }


}
