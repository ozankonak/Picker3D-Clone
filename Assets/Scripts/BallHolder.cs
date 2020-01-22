using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHolder : MonoBehaviour
{
    private int ballCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject,2f);
            ballCount++;
            GetComponentInParent<CheckPoint>().currentPointText.text = ballCount.ToString();
        }
    }
}
