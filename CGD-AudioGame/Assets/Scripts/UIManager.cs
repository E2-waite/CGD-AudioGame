﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enums;

public class UIManager : MonoBehaviour
{
    public GameObject AttractUI;
    public GameObject GameUI;
    public GameObject NextLevelUI;
    public GameObject RetryUI;
    LevelManager lm;

    void Start()
    {
        //AttractUI = GameObject.FindGameObjectWithTag("AttractUI");
        //GameUI = GameObject.FindGameObjectWithTag("GameUI");
        lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
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
                }

                if(lm.IsLevelLost())
                {
                    RetryUI.SetActive(true);
                    GameUI.SetActive(false);
                }
                else if(lm.IsLevelWon())
                {
                    NextLevelUI.SetActive(true);
                    GameUI.SetActive(false);
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
        }
        else {
            Debug.LogError("No Level Manager Found.");
        }
    }
}
