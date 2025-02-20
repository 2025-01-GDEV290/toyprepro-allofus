using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player Stats")]
    public int health = 3;
    public float walk = 6f;

    [Header("Player Glider")]
    public GameObject glider;
    public float air_time = 0f;
    public float jump_height = 2f;

    private CharacterController character_controller;
    private float gravity = 10f;
    private float vertical_velocity;

    private void Start()
    {
        character_controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float vertical_movement = Input.GetAxis("Vertical");
        float horizontal_movement = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(horizontal_movement, 0, vertical_movement);

        move *= walk;

        move.y = Gravity();

        character_controller.Move(move * Time.deltaTime);

    }

    private float Gravity()
    {
        if (character_controller.isGrounded)
        {
            air_time = 0;
            glider.SetActive(false);

            vertical_velocity = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                vertical_velocity = Mathf.Sqrt(jump_height * gravity * 2);
            }

        } 
        else
        {
            air_time += Time.deltaTime;

            if (Input.GetKey(KeyCode.Space) && air_time > 2f)
            {
                glider.SetActive(true);

                vertical_velocity -= 1 * Time.deltaTime;
            }
            else
            {
                glider.SetActive(false);

                vertical_velocity -= gravity * Time.deltaTime;
            }

        }

        return vertical_velocity;
    }
}
