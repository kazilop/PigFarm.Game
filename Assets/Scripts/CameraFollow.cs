using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;

    public GameObject player;

    private Vector3 distance;

    void Start()
    {
        cam = GetComponent<Camera>();
        distance = cam.transform.position - player.transform.position;

    }

    
    void FixedUpdate()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, player.transform.position + distance, 0.2f);
    }
}
