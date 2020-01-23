using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    public int CurrentLevel { get; set; } = 1;
    public int PartLevel { get; set; } = 0;
    public bool Started { get; set; }
    public bool Paused { get; set; }

    public int CurrentDiamond { get; private set; }
    public float DiamondLevelRate { get; set; } = 0;

    public int TotalDiamond { get; private set; }

    #endregion

    #region Unity Functions

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Paused = false;
        Started = false;

        if (PlayerPrefs.GetInt("diamond") != 0)
        {
            TotalDiamond = PlayerPrefs.GetInt("diamond");
            UIManager.instance.totalDiamondText.text = PlayerPrefs.GetInt("diamond").ToString();
        }
        else
            TotalDiamond = 0;

        DiamondLevelRate = 0;
    }

    #endregion

    #region Public Functions
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void NextLevel()
    {
        CurrentLevel++;
        PartLevel = 0;
        CurrentDiamond = 0;
        FindObjectOfType<BallHolder>().BallCount = 0;

        //reset checkpoint images
        foreach (var image in UIManager.instance.checkPointImages)
        {
            image.color = Color.white;
        }

        UIManager.instance.levelCompletedPanel.SetActive(false);

        Paused = false;
    }

    public void CalculateDiamonds()
    {
        DiamondLevelRate = FindObjectOfType<BallHolder>().BallCount / 100f;
        CurrentDiamond = (int)(200 * DiamondLevelRate);
        TotalDiamond += CurrentDiamond;
        PlayerPrefs.SetInt("diamond", TotalDiamond);
    }
#endregion
}
