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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        Hit_Points--;

        animation_state.Play("Hit", -1 , 0f);

    }

    public void OnDelete()
    {
        if (Hit_Points <= 0)
        {
            Destroy(gameObject);
        }
    }
}
