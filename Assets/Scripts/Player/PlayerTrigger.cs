using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FanPower")
        {
            other.gameObject.SetActive(false);
            StartCoroutine("StartFanPower");
        }
    }

    IEnumerator StartFanPower()
    {
        transform.Find("Hands").gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(20f);
        transform.Find("Hands").gameObject.SetActive(false);
    }
}
