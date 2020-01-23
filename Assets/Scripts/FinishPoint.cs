using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //If player will come to finish point
        if (other.gameObject.tag == "Player")
        {
            //Stop the player
            GameManager.instance.Paused = true;

            //calculate diamonds
            GameManager.instance.CalculateDiamonds();

            //Show the current diamond
            UIManager.instance.currentDiamondText.text = GameManager.instance.CurrentDiamond.ToString();

            //Show the diamond rate
            UIManager.instance.diamondRateText.text = "%" + (100 *GameManager.instance.DiamondLevelRate).ToString();

            //Show the total diamond
            UIManager.instance.totalDiamondText.text = GameManager.instance.TotalDiamond.ToString();

            //Open the level completed panel
            UIManager.instance.levelCompletedPanel.SetActive(true);

            //close level panel
            UIManager.instance.levelPanel.SetActive(false);
        }
    }
}
