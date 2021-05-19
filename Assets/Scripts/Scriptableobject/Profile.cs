using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Character", menuName = "Settings/Profile")]
public class Profile : ScriptableObject
{
    public string Nickname;

    public int numNoobGames = 0;
    public int noobScore = 0;
    public int noobCombo = 0;
    public int noobDeaths = 0;

    public int numMidGames = 0;
    public int midScore = 0;
    public int midCombo = 0;
    public int midDeaths = 0;

    public int numProGames = 0;
    public int proScore = 0;
    public int proCombo = 0;
    public int proDeaths = 0;

    public void GOverController(string state){
        switch (state){
            case "Noob":
                numNoobGames++;
                break;
            case "Mid":
                numMidGames++;
                break;
            case "Hard":
                numProGames++;
                break;
            default: break;
        }
        
    }

    public void ScoreController(string state){
        switch (state){
            case "Noob":
                noobScore++;
                break;
            case "Mid":
                midScore++;
                break;
            case "Hard":
                proScore++;
                break;
            default: break;
        }
    }

    public void ComboController(string state, int combo){
        switch (state){
            case "Noob":
                if(noobCombo < combo) noobCombo = combo;
                break;
            case "Mid":
                if(midCombo < combo) midCombo = combo;
                break;
            case "Hard":
                if(proCombo < combo) proCombo = combo;
                break;
            default: break;
        }
    }

    public void DeathController(string state){
        switch (state){
            case "Noob":
                noobDeaths++;
                break;
            case "Mid":
                midDeaths++;
                break;
            case "Hard":
                proDeaths++;
                break;
            default: break;
        }
    }

    public void Clear(){
        numNoobGames = 0;
        noobScore = 0;
        noobCombo = 0;
        noobDeaths = 0;

        numMidGames = 0;
        midScore = 0;
        midCombo = 0;
        midDeaths = 0;

        numProGames = 0;
        proScore = 0;
        proCombo = 0;
        proDeaths = 0;
    }

}
