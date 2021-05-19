using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsController : MonoBehaviour
{
        [SerializeField] Profile profile;

        public GameObject difficulti;
        public GameObject fGameOvers;
        public GameObject fScore;
        public GameObject fCombo;
        public GameObject fDeath;

        public GameObject fClear;
        public GameObject cam;


        public void SetAll(){
            difficulti.GetComponent<Text>().text = "All Stat";
            
            var allGames = profile.numNoobGames + profile.numMidGames + profile.numProGames;
            fGameOvers.GetComponent<Text>().text = "" + allGames;

            var allScore = profile.noobScore + profile.midScore + profile.proScore;
            fScore.GetComponent<Text>().text = "" + allScore;

            var allCombo = profile.noobCombo + profile.midCombo + profile.proCombo;
            fCombo.GetComponent<Text>().text = "" + allCombo;

            var allDeaths = profile.noobDeaths + profile.midDeaths + profile.proDeaths;
            fDeath.GetComponent<Text>().text = "" + allDeaths;
        }

        public void SetNoob(){
            difficulti.GetComponent<Text>().text = "Noob Stat";

            fGameOvers.GetComponent<Text>().text = "" + profile.numNoobGames;
            fScore.GetComponent<Text>().text = "" + profile.noobScore;
            fCombo.GetComponent<Text>().text = "" + profile.noobCombo;
            fDeath.GetComponent<Text>().text = "" + profile.noobDeaths;
        }

        public void SetMid(){
            difficulti.GetComponent<Text>().text = "Mid Stat";

            fGameOvers.GetComponent<Text>().text = "" + profile.numMidGames;
            fScore.GetComponent<Text>().text = "" + profile.midScore;
            fCombo.GetComponent<Text>().text = "" + profile.midCombo;
            fDeath.GetComponent<Text>().text = "" + profile.midDeaths;
        }

        public void SetPro(){
            difficulti.GetComponent<Text>().text = "Hard Stat";

            fGameOvers.GetComponent<Text>().text = "" + profile.numProGames;
            fScore.GetComponent<Text>().text = "" + profile.proScore;
            fCombo.GetComponent<Text>().text = "" + profile.proCombo;
            fDeath.GetComponent<Text>().text = "" + profile.proDeaths;
        }

        public void Clear(){
            if(fClear.GetComponent<Text>().text != "You shure?"){
                fClear.GetComponent<Text>().text = "You shure?";
            }else{
                fGameOvers.GetComponent<Text>().text = "0";
                fScore.GetComponent<Text>().text = "0";
                fCombo.GetComponent<Text>().text = "0";
                fDeath.GetComponent<Text>().text = "0";
                fClear.GetComponent<Text>().text = "Clear";
                profile.Clear();
                cam.GetComponent<SaveLoad>().ResetData();
            }
        }


}
