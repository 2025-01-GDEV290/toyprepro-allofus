using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    public Animator animation_state;

    public int Hit_Points = 3;
    
    void Start()
    {
        animation_state = GetComponent<Animator>();
    }

    private void OnMouseUpAsButton()
    {
        Hit_Points--;

        if (Hit_Points <= 0)
        {
            audiomanager.instance.onBreakSound();

            Destroy(gameObject);
        }
        else
        {
            audiomanager.instance.onHitSound();

            animation_state.Play("Hit", -1, 0f);
        }
        

    }

}
