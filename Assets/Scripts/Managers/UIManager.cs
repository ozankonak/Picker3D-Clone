using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    #region  Variables

    [Header("Panels")]

    public GameObject levelCompletedPanel;
    public GameObject levelFailedPanel;
    public GameObject levelPanel;


    [Header("Texts")]
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    public Text currentDiamondText;
    public Text diamondRateText;
    public Text totalDiamondText;

    [Header("Images")]
    public Image[] checkPointImages;

    [Header("GameObjects")]
    [SerializeField] private GameObject title;

    #endregion

    #region Unity Functions

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        title.gameObject.SetActive(true);
        levelPanel.SetActive(false);
        levelCompletedPanel.SetActive(false);
        levelFailedPanel.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance.Started)
        {
            title.SetActive(false);
            levelPanel.SetActive(true);
        }

        currentLevelText.text = GameManager.instance.CurrentLevel.ToString();
        nextLevelText.text = (GameManager.instance.CurrentLevel + 1).ToString();
    }

#endregion
}
