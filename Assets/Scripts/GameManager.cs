using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int currentLevel = 1;
    public int PartLevel { get; set; } = 0;
    public bool Started { get; set; }

    private void Awake()
    {
        instance = this;
    }

    private void LevelComplete()
    {
        currentLevel++;
        //TODO: Active Level Complete Panel

    }
}
