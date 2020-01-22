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

    [SerializeField] private GameObject title;
    [SerializeField] private GameObject levelPanel;

    public Image[] checkPointImages;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        title.gameObject.SetActive(true);
        levelPanel.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance.Started)
        {
            title.SetActive(false);
            levelPanel.SetActive(true);
        }
    }
}
