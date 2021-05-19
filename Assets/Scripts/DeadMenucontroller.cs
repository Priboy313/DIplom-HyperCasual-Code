using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadMenucontroller : MonoBehaviour
{
    [SerializeField] DataBase inGameSet;
    [SerializeField] Profile profile;
    public GameObject cam;
    public GameObject Player;
        public int score;
        public int combo;
        public int death;
    public GameObject startPos;
    public GameObject activePos;
        public GameObject difficulti;
        public GameObject fScore;
        public GameObject fCombo;
        public GameObject fDeath;

    public void ComboController(int comboP){
        if(combo < comboP) combo = comboP;
    }
    public void Death(){
        var objs = GameObject.FindGameObjectsWithTag("Scrap");

        for( int i = 0; i < objs.Length; i++ ){
                objs[i].SetActive(false); 
        }
        if(inGameSet.state == "Noob"){
            difficulti.GetComponent<Text>().text = "" + inGameSet.state + " №" + profile.numNoobGames;
        }else if(inGameSet.state == "Mid"){
            difficulti.GetComponent<Text>().text = "" + inGameSet.state + " №" + profile.numMidGames;
        }else{
            difficulti.GetComponent<Text>().text = "" + inGameSet.state + " №" + profile.numProGames;
        }
        fScore.GetComponent<Text>().text = ""+ score;
        fCombo.GetComponent<Text>().text = ""+ combo;
        fDeath.GetComponent<Text>().text = ""+ death;
        cam.GetComponent<SaveLoad>().SaveGame();
    }
    public void Restart(){
        if(inGameSet.state == "Noob"){
            profile.numNoobGames++;
            PlayerPrefs.SetInt("SavednumNoobGames", profile.numNoobGames);
        }else if(inGameSet.state == "Mid"){
            profile.numMidGames++;
            PlayerPrefs.SetInt("SavednumMidGames", profile.numMidGames);
        }else{
            profile.numProGames++;
            PlayerPrefs.SetInt("SavednumProGames", profile.numProGames);
        }
        SceneManager.LoadScene("X2");
    }
}
