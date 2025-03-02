using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Update()
    {
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move, Space.World);
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
   
}