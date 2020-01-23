using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHolder : MonoBehaviour
{
    public int BallCount { get; set; }

    private void Start()
    {
        BallCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject,2f);
            BallCount++;
            GetComponentInParent<CheckPoint>().currentPointText.text = BallCount.ToString();
        }
    }
}
