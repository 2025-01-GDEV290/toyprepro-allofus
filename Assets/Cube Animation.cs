using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphereClick : MonoBehaviour
{
    public Animator squareAnimator; // Assign this in the Inspector

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            if (squareAnimator != null)
            {
                squareAnimator.SetTrigger("PlayAnimation"); // Make sure this matches your animation trigger
            }
        }
    }
}