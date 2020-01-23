using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float forceSpeed = 10f;

    private Rigidbody rigid;

    private Vector3 targetPos;
    private float speed = 2.0f;
    private float clampXValue = 3.0f;

    public Vector3 ForcePower { get; private set; }

    #endregion

    #region Unity Functions

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        ForcePower = Vector3.forward * Time.deltaTime * forceSpeed * rigid.mass * 10.000f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.Started && !GameManager.instance.Paused && rigid.velocity.magnitude < 5f)
            rigid.AddRelativeForce(ForcePower);
        else if (GameManager.instance.Paused)
            StopThePlayer();
    }

    #endregion

    #region Public Functions

    public void MoveWithDrag()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);


        Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        followXonly.x = Mathf.Clamp(followXonly.x, -clampXValue, clampXValue);
        transform.position = Vector3.Lerp(transform.position, followXonly, speed * Time.deltaTime);
    }

    public void StopThePlayer()
    {
        rigid.velocity = Vector3.zero;
    }

    #endregion

}
