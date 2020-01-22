using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    //We called UI object in there, because every checkpoint object have their own texts so we cant use these texts in UI Manager, these are not general texts.
    public Text currentPointText;
    public Text maxPointText;

    private bool passedCheckpoint = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            //Checking Process
            Waiting();
            //Give computer the 3 seconds for calculating (waiting balls for being sure, every balls we pushed calculated or not)
            Invoke("Checking",3f);
        }
    }

    private void Update()
    {
        CalculatingBalls();
    }

    private void Waiting()
    {
        //Stopping Player First
        GameManager.instance.Paused = true;
        //TODO:Some VFX would be add to game 
        //TODO:Sound Effects would be add to game
    }

    private void Checking()
    {
        //If enough ball to pass checkpoint
        if (passedCheckpoint)
        {
            //Fix the checkpoint box's position
            Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
            transform.position = pos;
            transform.Find("part1").gameObject.SetActive(false);
            transform.Find("part2").gameObject.SetActive(false);

            //Increase checkpoint level
            GameManager.instance.PartLevel++;
            //Paint the checkpoint images
            if (GameManager.instance.PartLevel < 4)
            UIManager.instance.checkPointImages[GameManager.instance.PartLevel - 1].color = Color.yellow;
            //Move the player again
            GameManager.instance.Paused = false;
        }
        else
        {
            //TODO: FAIL SCREEN && GAME OVER
            GameManager.instance.Paused = true;
            UIManager.instance.levelFailedPanel.SetActive(true);
        }
            
    }

    private void CalculatingBalls()
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

}
