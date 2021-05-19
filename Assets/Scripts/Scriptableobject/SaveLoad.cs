using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveLoad: MonoBehaviour
{
    [SerializeField] public Profile profile;
    public GameObject ButController;
    public string Nickname;
    public int numNoobGames;
    public int noobScore;
    public int noobCombo;
    public int noobDeaths;
    public int numMidGames;
    public int midScore;
    public int midCombo;
    public int midDeaths;
    public int numProGames;
    public int proScore;
    public int proCombo;
    public int proDeaths;
    [SerializeField] public Themes themes;
    public int colorNumber;

    private void Start() {
        LoadGame();
    }

    void GetData(){
        Nickname =         profile.Nickname;
        numNoobGames =     profile.numNoobGames;
        noobScore =        profile.noobScore;
        noobCombo =        profile.noobCombo;
        noobDeaths =       profile.noobDeaths;
        numMidGames =      profile.numMidGames;
        midScore =         profile.midScore;
        midCombo =         profile.midCombo;
        midDeaths =        profile.midDeaths;
        numProGames =      profile.numProGames;
        proScore =         profile.proScore;
        proCombo =         profile.proCombo;
        proDeaths =        profile.proDeaths;
        colorNumber =      themes.colorNumber;
    }

    public void SaveGame(){
        GetData();
        PlayerPrefs.SetString("SavedNickname",Nickname);
        Debug.Log("Set Nick =   "+ Nickname);
        PlayerPrefs.SetInt("SavednumNoobGames",numNoobGames);
        PlayerPrefs.SetInt("SavednoobScore",noobScore);
        PlayerPrefs.SetInt("SavednoobCombo",noobCombo);
        PlayerPrefs.SetInt("SavednoobDeaths",noobDeaths);
        PlayerPrefs.SetInt("SavednumMidGames",numMidGames);
        PlayerPrefs.SetInt("SavedmidScore",midScore);
        PlayerPrefs.SetInt("SavedmidCombo",midCombo);
        PlayerPrefs.SetInt("SavedmidDeaths",midDeaths);
        PlayerPrefs.SetInt("SavednumProGames",numProGames);
        PlayerPrefs.SetInt("SavedproScore",proScore);
        PlayerPrefs.SetInt("SavedproCombo",proCombo);
        PlayerPrefs.SetInt("SavedproDeaths",proDeaths);
        PlayerPrefs.SetInt("SavedcolorNumber",colorNumber);
        PlayerPrefs.Save();
        Debug.Log("Save");
    }

    public void LoadGame(){
        if(SceneManager.GetActiveScene().name == "Main"){ 
            if(PlayerPrefs.HasKey("SavednumNoobGames")){

                Nickname =      PlayerPrefs.GetString("SavedNickname");
                numNoobGames =  PlayerPrefs.GetInt("SavednumNoobGames");
                noobScore =     PlayerPrefs.GetInt("SavednoobScore");
                noobCombo =     PlayerPrefs.GetInt("SavednoobCombo");
                noobDeaths =    PlayerPrefs.GetInt("SavednoobDeaths");
                numMidGames =   PlayerPrefs.GetInt("SavednumMidGames");
                midScore =      PlayerPrefs.GetInt("SavedmidScore");
                midCombo =      PlayerPrefs.GetInt("SavedmidCombo");
                midDeaths =     PlayerPrefs.GetInt("SavedmidDeaths");
                numProGames =   PlayerPrefs.GetInt("SavednumProGames");
                proScore =      PlayerPrefs.GetInt("SavedproScore");
                proCombo =      PlayerPrefs.GetInt("SavedproCombo");
                proDeaths =     PlayerPrefs.GetInt("SavedproDeaths");
                colorNumber =   PlayerPrefs.GetInt("SavedcolorNumber");
            }else{
                ResetData();
                Nickname = "";
                numNoobGames =  PlayerPrefs.GetInt("SavednumNoobGames");
                noobScore =     PlayerPrefs.GetInt("SavednoobScore");
                noobCombo =     PlayerPrefs.GetInt("SavednoobCombo");
                noobDeaths =    PlayerPrefs.GetInt("SavednoobDeaths");
                numMidGames =   PlayerPrefs.GetInt("SavednumMidGames");
                midScore =      PlayerPrefs.GetInt("SavedmidScore");
                midCombo =      PlayerPrefs.GetInt("SavedmidCombo");
                midDeaths =     PlayerPrefs.GetInt("SavedmidDeaths");
                numProGames =   PlayerPrefs.GetInt("SavednumProGames");
                proScore =      PlayerPrefs.GetInt("SavedproScore");
                proCombo =      PlayerPrefs.GetInt("SavedproCombo");
                proDeaths =     PlayerPrefs.GetInt("SavedproDeaths");
                colorNumber =   PlayerPrefs.GetInt("SavedcolorNumber");
            }

            WriteData();
            ButController.GetComponent<ButController>().ThemeSwap();
            SaveGame();
        }
    }
    void WriteData(){
        profile.Nickname  =       Nickname;
        profile.numNoobGames  =   numNoobGames;
        profile.noobScore  =      noobScore;
        profile.noobCombo  =      noobCombo;
        profile.noobDeaths  =     noobDeaths;
        profile.numMidGames  =    numMidGames;
        profile.midScore  =       midScore;
        profile.midCombo  =       midCombo;
        profile.midDeaths  =      midDeaths;
        profile.numProGames  =    numProGames;
        profile.proScore  =       proScore;
        profile.proCombo  =       proCombo;
        profile.proDeaths  =      proDeaths;
        themes.colorNumber  =     colorNumber;
    }

    public void ResetData(){
            PlayerPrefs.SetInt("SavednumNoobGames", 0);
            PlayerPrefs.SetInt("SavednoobScore", 0);
            PlayerPrefs.SetInt("SavednoobCombo", 0);
            PlayerPrefs.SetInt("SavednoobDeaths", 0);
            PlayerPrefs.SetInt("SavednumMidGames", 0);
            PlayerPrefs.SetInt("SavedmidScore", 0);
            PlayerPrefs.SetInt("SavedmidCombo", 0);
            PlayerPrefs.SetInt("SavedmidDeaths", 0);
            PlayerPrefs.SetInt("SavednumProGames", 0);
            PlayerPrefs.SetInt("SavedproScore", 0);
            PlayerPrefs.SetInt("SavedproCombo", 0);
            PlayerPrefs.SetInt("SavedproDeaths", 0);
    }

}
