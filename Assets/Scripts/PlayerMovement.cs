using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody rigid;

    public Vector3 ForcePower { get; set; }
    public Vector3 OriginalForcePower { get; set; }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        OriginalForcePower = Vector3.forward * Time.deltaTime * speed * rigid.mass * 10.000f;
        ForcePower = Vector3.forward * Time.deltaTime * speed * rigid.mass * 10.000f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.magnitude < 10f)
        rigid.AddRelativeForce(ForcePower);
    }


}
