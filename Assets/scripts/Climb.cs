using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{

    public float climbSpeed = 3f; 
    private CharacterController characterController; 
    private Vector3 moveDirection = Vector3.zero; 
    private bool isOnLadder = false; 

    void Start()
    {
     
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController not found on player object!");
        }
    }

    void Update()
    {
        if (isOnLadder)
        {
            
            float verticalMove = Input.GetAxis("Vertical") * climbSpeed;
            moveDirection = new Vector3(0, verticalMove, 0);

            
            characterController.slopeLimit = 90f;
        }
        else
        {
           
            moveDirection.y = -9.81f;
            characterController.slopeLimit = 45f; 
        }

        
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            
            isOnLadder = true;
            characterController.detectCollisions = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            
            isOnLadder = false;
            characterController.detectCollisions = true; 
        }
    }

}
