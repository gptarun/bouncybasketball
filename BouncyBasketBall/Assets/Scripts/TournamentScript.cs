using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TournamentScript : MonoBehaviour {
    private readonly List<string> teamList = new List<string>(new string[] { "Africa", "Argentina", "Australia", "Brazil", "China", "France", "India", "Mexico", "Philippines", "Russia", "Serbia", "Singapore", "Spain", "Thailand", "United States", "Yugoslavia" });
    private readonly List<string> teamListShort = new List<string>(new string[] { "Afr", "Arg", "Aus", "Bra", "Chi", "Fra", "Ind", "Mex", "Phi", "Rus", "Ser", "Sin", "Spa", "Tha", "Usa", "Yug" });    
    //Tournament config params
    private readonly int numberOfMatches = 7;
    //Setting all Team flags as array
    [SerializeField] private Image[] flagImages;
    private Dictionary<int,TeamScript> TeamData = new Dictionary<int, TeamScript>();
    private TeamScript[] team = new TeamScript[8];
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 8; i++)
        {
            if (i == 0)
            {
                team[i] = new TeamScript(teamList[i], teamListShort[i], "Human", flagImages[i]);
                TeamData.Add(i, team[i]);
            }
            else
            {
                team[i] = new TeamScript(teamList[i], teamListShort[i], "Bot", flagImages[i]);
                TeamData.Add(i, team[i]);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}    
    public void StartTournament()
    {
        for (int matchCount = 0; matchCount < numberOfMatches; matchCount++)
        {        
            PlayMatch();
        }
        SetWinner();
    }

    private void SetWinner()
    {
        //Need to end Tournament here
    }

    private void PlayMatch()
    {

    }

    public void SetTeam(string teamAName, string teamBName, string modeA, string modeB, Sprite flagA, Sprite flagB, string currButtonName)
    {       
        switch (currButtonName){
            case "GroupA":            
                SetTeamGeneric(teamAName,teamBName,modeA,modeB,flagA,flagB,currButtonName,0,1);   
                break;
            case "GroupB":
                SetTeamGeneric(teamAName, teamBName, modeA, modeB, flagA, flagB, currButtonName, 2, 3);
                break;
            case "GroupC":
                SetTeamGeneric(teamAName, teamBName, modeA, modeB, flagA, flagB, currButtonName, 4, 5);
                break;
            case "GroupD":
                SetTeamGeneric(teamAName, teamBName, modeA, modeB, flagA, flagB, currButtonName, 6, 7);
                break;
            default:
                Debug.Log("Invalid Object");
                break;
        }
        
    }

    private void SetTeamGeneric(string teamAName, string teamBName, string modeA, string modeB, Sprite flagA, Sprite flagB, string currButtonName, int index1, int index2)
    {
        team[index1].Flag = GameObject.Find(currButtonName).transform.Find("TeamA").GetComponent<Image>();
        team[index1].Flag.overrideSprite = flagA;
        team[index1].TeamName = teamAName;
        team[index1].ShortName = teamAName.Substring(0, 4);
        team[index1].Mode = modeA;

        team[index2].Flag = GameObject.Find(currButtonName).transform.Find("TeamB").GetComponent<Image>();
        team[index2].Flag.overrideSprite = flagB;
        team[index2].TeamName = teamBName;
        team[index2].ShortName = modeB;
        team[index2].Mode = teamBName.Substring(0, 4);
    }
}
