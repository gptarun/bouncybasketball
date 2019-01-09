using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectTeam : MonoBehaviour {

    private List<string> teamList = new List<string>(new string[] { "Africa", "Argentina", "Australia", "Brazil", "China", "France", "India", "Mexico", "Philippines", "Russia", "Serbia", "Singapore", "Spain", "Thailand", "United States", "Yugoslavia"});
    private readonly List<int> teamRating = new List<int>(new int[] { 2,3,2,3,2,3,2,1,2,3,2,2,3,2,3,3 });
    //Choosing Teams
    [SerializeField] TextMeshProUGUI teamAChoice;
    [SerializeField] TextMeshProUGUI teamBChoice;
    //Choosing Human or AI mode
    [SerializeField] Button changeModeA;
    [SerializeField] Button changeModeB;
    private int modeCounterA = 0;
    private int modeCounterB = 1;
    //Chaning sprite AI to Human and vice-versa
    public Sprite[] mode;
    private int indexA = 9;
    private int indexB = 9;
    //Calculating stars
    public GameObject[] teamAStar;
    public GameObject[] teamBStar;
    //Loading flags
    public Sprite[] flags;
    [SerializeField] Button teamAFlag;
    [SerializeField] Button teamBFlag;
    void Start () {
        teamAChoice.text = teamList[indexA].ToString();
        teamBChoice.text = teamList[indexA].ToString();
        changeModeA.image.sprite = mode[modeCounterA];
        changeModeB.image.sprite = mode[modeCounterB];
        flags = Resources.LoadAll<Sprite>("Flags");
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
        RankCalculation(indexA, teamAStar);
        SetFlagoFTeam(indexA, teamAFlag);
    }
    public void LeftButtonA()
    {
        indexA--;
        if (indexA <= 0)
        {
            indexA = teamList.Count - 1;
        }
        teamAChoice.text = teamList[indexA].ToString();
        RankCalculation(indexA, teamAStar);
        SetFlagoFTeam(indexA, teamAFlag);

    }
    public void RighButtonB()
    {
        indexB++;
        if (indexB >= teamList.Count)
        {
            indexB = 0;
        }
        teamBChoice.text = teamList[indexB].ToString();
        RankCalculation(indexB, teamBStar);
        SetFlagoFTeam(indexB, teamBFlag);
    }
    public void LeftButtonB()
    {
        indexB--;
        if (indexB <= 0)
        {
            indexB = teamList.Count - 1;
        }
        teamBChoice.text = teamList[indexB].ToString();
        RankCalculation(indexB, teamBStar);
        SetFlagoFTeam(indexB, teamBFlag);
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

    public void RankCalculation(int value, GameObject[] gameObj)
    {
        ResetRank(gameObj);
        for (int i = 0; i < teamRating[value]; i++)
        {
            gameObj[i].SetActive(true);
        }        
    }
    public void ResetRank(GameObject[] gameObj)
    {
        for (int i = 0; i < 3; i++)
        {
            gameObj[i].SetActive(false);
        }
    }
    public void SetFlagoFTeam(int flagCount,Button flagButton)
    {
        flagButton.image.sprite = flags[flagCount];
    }
}
