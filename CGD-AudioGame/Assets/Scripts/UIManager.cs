﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enums;

public class UIManager : MonoBehaviour
{
    public GameObject AttractUI;
    public GameObject GameUI;

    public GameObject MenuUI;
    public GameObject TimerUI;
    public GameObject CurrentLevelUI;
    public GameObject SettingsButtonUI;

    public GameObject AudioSettingsUI;

    public GameObject NextLevelUI;
    public GameObject RetryUI;
    LevelManager lm;

    public bool paused;

    void Start()
    {
        //AttractUI = GameObject.FindGameObjectWithTag("AttractUI");
        //GameUI = GameObject.FindGameObjectWithTag("GameUI");
        lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        paused = false;
    }

    void Update()
    {
        if(lm)
        {
            if(lm.GameState() == GAMESTATE.game)
            {
                if(!GameUI.activeSelf)
                {
                    GameUI.SetActive(true);
                    AttractUI.SetActive(false);
                    AudioSettingsUI.SetActive(false);
                    MenuUI.SetActive(false);
                }

                if(lm.IsLevelLost())
                {
                    RetryUI.SetActive(true);
                    GameUI.SetActive(false);
                    AudioSettingsUI.SetActive(false);
                    MenuUI.SetActive(false);
                }
                else if(lm.IsLevelWon())
                {
                    NextLevelUI.SetActive(true);
                    GameUI.SetActive(false);
                    AudioSettingsUI.SetActive(false);
                    MenuUI.SetActive(false);
                }                
      
            }
            else if(lm.GameState() == GAMESTATE.attract)
            {
                if(!AttractUI.activeSelf)
                {
                    GameUI.SetActive(false);
                    AttractUI.SetActive(true);
                }
            }
            else if(lm.GameState() == GAMESTATE.pause)
            {
                GameUI.SetActive(false);
                AttractUI.SetActive(false);
                AudioSettingsUI.SetActive(false);
                MenuUI.SetActive(true);
            }
            else if (lm.GameState() == GAMESTATE.audioSettings)
            {
                GameUI.SetActive(false);
                AttractUI.SetActive(false);
                MenuUI.SetActive(false);
                AudioSettingsUI.SetActive(true);
            }
        }
        else {
            Debug.LogError("No Level Manager Found.");
        }
    }
}

