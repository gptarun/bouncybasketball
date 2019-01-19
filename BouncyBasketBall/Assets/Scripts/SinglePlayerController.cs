using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SinglePlayerController : MonoBehaviour {
    private string teamAMode;
    private string teamBMode;
    private string teamAFullName;
    private string teamBFullName;
    [SerializeField] Text quater;
    private int totalCounter;
    private int quaterCounter = 1;
    [SerializeField] Text quaterTimer;
    private int qTimer;
    [SerializeField] Text teamAScore;
    private int scoreA;
    [SerializeField] Text teamBScore;
    private int scoreB;
    [SerializeField] Text teamAName;
    [SerializeField] Text teamBName;
    [SerializeField] GameObject canvasObject;
    [SerializeField] TextMeshProUGUI winnerName;
    [SerializeField] Button pauseButton;
    private static bool pauseButtonPressed = false;
    bool gameOver = false;
    // Use this for initialization
    void Start () {
        pauseButtonPressed = false;
        totalCounter = OptionMenuScript.quaterCounter;
        quater.text = "Q" + quaterCounter;
        qTimer = OptionMenuScript.quaterDuration;
        quaterTimer.text = "" + qTimer;
        scoreA = 5;
        scoreB = 8;
        teamAScore.text = scoreA.ToString();
        teamBScore.text = scoreB.ToString();
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(pauseButtonPressed);
        if (!pauseButtonPressed)
        {
            if (qTimer > -1)
            {
                quaterTimer.text = qTimer.ToString();
            }
            if ((quaterCounter == totalCounter) && (qTimer < 0))
            {
                if (!gameOver)
                {
                    gameOver = true;
                    GameWinner();

                }
            }
        }
    }

    public void SinglePlayerTeams()
    {
        Debug.Log("Game Begins");        
    }

    public void SetTeams(string teamANameSelected, string teamBNameSelected, string modeA, string modeB)
    {
        teamAName.text = teamANameSelected.Substring(0, 4);
        teamBName.text = teamBNameSelected.Substring(0, 4);
        teamAMode = modeA;
        teamBMode = modeB;
        teamAFullName = teamANameSelected;
        teamBFullName = teamBNameSelected;
    }
   
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
   
    public void PauseGame()
    {
        pauseButtonPressed = true;
        Time.timeScale = 0f;
    }
    public void UnPauseGame()
    {
        pauseButtonPressed = false;
        Time.timeScale = 1f;        
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            qTimer--;
        }
    }

    public void GameWinner()
    {
        if (scoreA > scoreB)
        {
            Debug.Log("Team A wins");
            winnerName.text = teamAFullName + " Wins!";
            MatchEnded();
        }
        else if (scoreA < scoreB)
        {
            Debug.Log("Team B wins");
            winnerName.text = teamBFullName + " Wins!";
            MatchEnded();
        }
        else
        {
            Debug.Log("Draw");
        }
    }
    public void MatchEnded()
    {
        pauseButton.interactable = false;
        canvasObject.SetActive(true);        
    }
}
