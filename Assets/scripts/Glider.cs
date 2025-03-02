using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{
    public float fallSpeed = 0f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && rb.velocity.y < 0 && Mathf.Abs(rb.velocity.y) > fallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * fallSpeed);
        }
    }

    public void StartGliding()
    {
        fallSpeed = 1f; 
    }

    public void StopGliding()
    {
        fallSpeed = 0f;
    }
}
