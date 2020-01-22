using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public Text currentPointText;
    public Text maxPointText;
    private bool passedCheckpoint = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Checking();
            
            Invoke("CheckTrue",3f);


        }
    }

    private void Update()
    {
        if (int.Parse(currentPointText.text) >= int.Parse(maxPointText.text))
        {
            passedCheckpoint = true;
        }
        else
        {
            passedCheckpoint = false;
        }
    }

    private void Checking()
    {
        //Stopping Player First
        FindObjectOfType<PlayerMovement>().ForcePower = Vector3.zero;
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        //Check Counts

    }

    private void CheckTrue()
    {
        if (passedCheckpoint)
        {
            Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
            transform.position = pos;
            transform.Find("part1").gameObject.SetActive(false);
            transform.Find("part2").gameObject.SetActive(false);


            GameManager.instance.PartLevel++;
            UIManager.instance.checkPointImages[GameManager.instance.PartLevel - 1].color = Color.yellow;

            //Moving Player again with same force
            FindObjectOfType<PlayerMovement>().ForcePower = FindObjectOfType<PlayerMovement>().OriginalForcePower;
        }
        else
        {
            //TODO: FAIL SCREEN && GAME OVER
        }
            
    }

}
