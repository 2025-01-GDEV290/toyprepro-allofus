using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public Camera main_camera;

    public GameObject fish;
    public LineRenderer fishing_line;

    
    void Start()
    {
        fishing_line = GetComponent<LineRenderer>();
        fishing_line.SetPosition(0, fish.transform.position);
    }

    
    void Update()
    {
        Vector3 mouse_position = main_camera.ScreenToWorldPoint(Input.mousePosition);
        mouse_position.z = 0f;

        fishing_line.SetPosition(1, mouse_position);
    }
}
