using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 offset;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        offset = transform.position - playerTransform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        
        transform.position = offset + playerTransform.position;
    }
}
