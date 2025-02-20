using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class golem : MonoBehaviour
{
    public GameObject floor;
    public Collider floor_collider;
    public Bounds floor_bounds;

    public Vector3 random_psoition;

    public static golem golem_instance;
    public GameObject text_object;

    public TextMesh rock_text;

    public int rock_counter;
    public int speed = 3;

    public bool alive = false;
    
    void Start()
    {
        golem_instance = this;

        rock_text = text_object.GetComponent<TextMesh>();

        floor_collider = floor.GetComponent<Collider>();
        floor_bounds = floor_collider.bounds;

        NewPosition();
    }


    void Update()
    {
        if (alive)
        {
            if (transform.position != random_psoition)
            {
                transform.position = Vector3.MoveTowards(transform.position, random_psoition, speed * Time.deltaTime);
            }
            else
            {
                NewPosition();
            }
        }
        
    }

    public void AddRock()
    {
        rock_counter++;

        rock_text.text = rock_counter.ToString();

        if (rock_counter >= 3 && !alive)
        {
            alive = true;
        }
    }

    public void NewPosition()
    {
        float random_x = Random.Range(floor_bounds.min.x, floor_bounds.max.x);
        float random_y = Random.Range(floor_bounds.min.y, floor_bounds.max.y);

        random_psoition = new Vector3(random_x, random_y, 0.75f);
    }
}
