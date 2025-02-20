using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public bool is_on = false;
    public float time = 0f;

    [Header("Componenents")]
    public GameObject particle_system;
    public GameObject air_collision;
    private Air air_script;

    private void Start()
    {
        air_script = air_collision.GetComponent<Air>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= 5f && !is_on)
        {
            TurnOn();
            time = 0f;
        }

        if (time >= 5f && is_on)
        {
            TurnOff();
            time = 0f;
        }

    }

    public void TurnOn()
    {
        is_on = true;
        air_script.activated = is_on;

        particle_system.SetActive(true);
    }

    public void TurnOff()
    {
        is_on = false;
        air_script.activated = is_on;

        particle_system.SetActive(false);
    }


}
