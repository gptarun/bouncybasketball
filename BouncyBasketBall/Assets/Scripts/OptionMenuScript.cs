﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class OptionMenuScript : MonoBehaviour {
    //All option menu UI
    //number of quaters in game
    [SerializeField] TextMeshProUGUI noQuater;
    private int quaterCounter = 4;
    //Difficulty level of Game Easy or Hard
    [SerializeField] TextMeshProUGUI difficulty;
    List<string> diffLevel = new List<string>(new string[] {"EASY","HARD" });
    //Make sound effects ON/OFF
    [SerializeField] Toggle sound;
    //Set team size - 1, 2 or 3
    [SerializeField] TextMeshProUGUI teamSize;
    private int teamSizeCounter = 3;
    //Set quater time 30, 60, 90
    [SerializeField] TextMeshProUGUI quaterTime;
    private int quaterDuration = 30;
    //Switch side after Number of quaters/2
    [SerializeField] Toggle switchSide;
    //Make game music ON/OFF
    [SerializeField] Toggle music;
	// Use this for initialization
	void Start () {
        noQuater.text = quaterCounter.ToString();
        difficulty.text = diffLevel[0];
        teamSize.text = teamSizeCounter.ToString();
        quaterTime.text = quaterDuration.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onToggle()
    {

    }

    public void ChangeQuaterNumber()
    {
        quaterCounter--;
        if(quaterCounter == 0)
        {
            quaterCounter = 4;
        }
        noQuater.text = quaterCounter.ToString();
    }

    public void ChangeDifficulty()
    {
        if (difficulty.text.Equals("EASY")){
            difficulty.text = diffLevel[1];
        }
        else
        {
            difficulty.text = diffLevel[0];
        }
    }

    public void ChangeTeamSize()
    {
        teamSizeCounter--;
        if (teamSizeCounter == 0)
        {
            teamSizeCounter = 3;
        }
        teamSize.text = teamSizeCounter.ToString();
    }

    public void ChangeQuaterTime()
    {
        quaterDuration = quaterDuration + 30;
        if(quaterDuration == 120)
        {
            quaterDuration = 30;
        }
        quaterTime.text = quaterDuration.ToString();
    }
}