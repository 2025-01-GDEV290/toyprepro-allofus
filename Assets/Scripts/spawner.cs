using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject floor;
    public Collider floor_collider;
    public Bounds floor_bounds;

    public GameObject rock_prefab;

    public float time = 0f;


    void Start()
    {
        floor_collider = floor.GetComponent<Collider>();
        floor_bounds = floor_collider.bounds;
    }


    void Update()
    {
        time += Time.deltaTime;

        if (time >= 1f )
        {
            float random_x = Random.Range(floor_bounds.min.x, floor_bounds.max.x);
            float random_y = Random.Range(floor_bounds.min.y, floor_bounds.max.y);

            Vector3 random_spawn = new Vector3(random_x, random_y, 0.75f);

            Instantiate(rock_prefab, random_spawn, Quaternion.identity);

            time = 0f;
        }
    }
}
