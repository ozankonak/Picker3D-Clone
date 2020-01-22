using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.Started)
            GameManager.instance.Started = true;
        else if (Input.GetMouseButton(0) && GameManager.instance.Started && !GameManager.instance.Paused)
            GetComponent<PlayerMovement>().MoveWithDrag();
    }
}
