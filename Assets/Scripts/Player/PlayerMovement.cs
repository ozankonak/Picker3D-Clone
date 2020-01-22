using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceSpeed = 10f;

    private Rigidbody rigid;

    private Vector3 targetPos;
    private float speed = 2.0f;

    public Vector3 ForcePower { get; set; }
    public Vector3 OriginalForcePower { get; set; }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        OriginalForcePower = Vector3.forward * Time.deltaTime * forceSpeed * rigid.mass * 10.000f;
        ForcePower = Vector3.forward * Time.deltaTime * forceSpeed * rigid.mass * 10.000f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.Started)
        {
            if (rigid.velocity.magnitude < 5f)
                rigid.AddRelativeForce(ForcePower);
        }
    }

    public void MoveWithDrag()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);


        Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        followXonly.x = Mathf.Clamp(followXonly.x, -3.5f, 3.5f);
        transform.position = Vector3.Lerp(transform.position, followXonly, speed * Time.deltaTime);
    }


}
