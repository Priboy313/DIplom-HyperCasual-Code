using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrapSpawner : MonoBehaviour
{
    [SerializeField] DataBase inGameSet;
    public GameObject scrap;
    public GameObject player;
    private int score;

    private void Start() {
        score = player.GetComponent<x2_PlayerController>().score;
    }
    
public void ScrapSpawn(){
    score = player.GetComponent<x2_PlayerController>().score;
             //спавнер мусора
        switch(score)
        {
            case 0:
                Instantiate(scrap);
                break;

            case 5: // #2
                if(inGameSet.scrapTact == 2 || inGameSet.scrapTact == 1) Instantiate(scrap);
                break;

            case 10: // #3
                if(inGameSet.scrapTact == 3 || inGameSet.scrapTact == 1) Instantiate(scrap);
                break;

            case 15: // #4
                if(inGameSet.scrapTact == 2 || inGameSet.scrapTact == 1) Instantiate(scrap);
                break;

            case 20: // #5
                if(inGameSet.scrapTact == 1) Instantiate(scrap);
                break;

            case 23: // #6
                Instantiate(scrap);
                break;

            case 25: // #7
                if(inGameSet.scrapTact == 1) Instantiate(scrap);
                break;

            case 30: // #8
                if(inGameSet.scrapTact == 2) Instantiate(scrap);
                break;

            case 33: // #9
                if(inGameSet.scrapTact == 3) Instantiate(scrap);
                break;

            case 40: // #10
                if(inGameSet.scrapTact == 2) Instantiate(scrap);
                break;
            
            case 45: // #11
                break;

            case 50: // #12
                if(inGameSet.scrapTact == 3 || inGameSet.scrapTact == 2) Instantiate(scrap);
                break;

            default: break;
        } //switch
        }
}
