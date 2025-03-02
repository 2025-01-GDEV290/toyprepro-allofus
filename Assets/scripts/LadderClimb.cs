using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 3f;
    private bool isClimbing = false;
    private bool nearLadder = false;
    private Rigidbody rb;
    private Vector3 originalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity;  
    }

    void Update()
    {
        if (isClimbing)
        {
           
            Physics.gravity = Vector3.zero;

            float verticalInput = Input.GetAxis("Vertical");  
            rb.velocity = new Vector3(rb.velocity.x, verticalInput * climbSpeed, rb.velocity.z);
        }
        else
        {
            
            Physics.gravity = originalGravity;
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            nearLadder = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            nearLadder = false;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (nearLadder && Input.GetButton("Climb"))
        {
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }
    }
}
