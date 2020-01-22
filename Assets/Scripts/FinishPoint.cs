using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private GameObject cam;

    private void Awake()
    {
        cam = Camera.main.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cam.transform.position = new Vector3(cam.transform.position.x,3f,cam.transform.position.z);
            cam.transform.rotation = Quaternion.Euler(4f,0f,0f);
        }
    }
}
