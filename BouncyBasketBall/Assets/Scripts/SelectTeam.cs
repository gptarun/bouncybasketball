using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectTeam : MonoBehaviour {

    private List<string> teamList = new List<string>(new string[] { "HOV","LAC","LAL", "MIL", "MIN", "NOP", "NYK", "ORL", "PHI", "PHO", "POR", "SAC", "UTA", "WAS", "BRO", "CHA", "CHI", "DAL", "DET", "DEN" });
    //private List<int> teamRating = new List<int>(new int[] { 2, 3, 1, 1, 1, 2, 1, 2, 1, 1, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2 });
    [SerializeField] TextMeshProUGUI teamAChoice;
    [SerializeField] TextMeshProUGUI teamBChoice;
    [SerializeField] Button changeModeA;
    [SerializeField] Button changeModeB;
    private int modeCounterA = 0;
    private int modeCounterB = 1;
    public Sprite[] mode;
    private int indexA = 9;
    private int indexB = 9;

    void Start () {
        teamAChoice.text = teamList[indexA].ToString();
        teamBChoice.text = teamList[indexA].ToString();
        changeModeA.image.sprite = mode[modeCounterA];
        changeModeB.image.sprite = mode[modeCounterB];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RighButtonA()
    {
        indexA++;
        if (indexA >= teamList.Count)
        {
            indexA = 0;
        }
        teamAChoice.text = teamList[indexA].ToString();
    }
    public void LeftButtonA()
    {
        indexA--;
        if (indexA <= 0)
        {
            indexA = teamList.Count - 1;
        }
        teamAChoice.text = teamList[indexA].ToString();
    }
    public void RighButtonB()
    {
        indexB++;
        if (indexB >= teamList.Count)
        {
            indexB = 0;
        }
        teamBChoice.text = teamList[indexB].ToString();
    }
    public void LeftButtonB()
    {
        indexB--;
        if (indexB <= 0)
        {
            indexB = teamList.Count - 1;
        }
        teamBChoice.text = teamList[indexB].ToString();
    }
    public void SelectModeOnA()
    {
        modeCounterA++;
        if (modeCounterA % 2 == 0)
        {
            changeModeA.image.sprite = mode[0];
        }
        else
        {
            changeModeA.image.sprite = mode[1];
        }
    }
    public void SelectModeOnB()
    {
        modeCounterB++;
        if (modeCounterB % 2 == 0)
        {
            changeModeB.image.sprite = mode[0];
        }
        else
        {
            changeModeB.image.sprite = mode[1];
        }
    }
}
