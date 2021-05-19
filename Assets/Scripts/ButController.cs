using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButController : MonoBehaviour
{

    [SerializeField] Profile profile;
    [SerializeField] Themes themes;

    public GameObject nameString;
    public GameObject mainMenu;
    public GameObject startMenu;
    public GameObject profileMenu;
    public GameObject statsMenu;

    public GameObject startMenuPos;
    private Vector3 startPos;
    public GameObject activeMenuPos;
    private Vector3 activePos;
    public float menuSpeed = 1f;

    private void Start() {
            nameString.GetComponent<Text>().text = profile.Nickname;

        startPos = startMenuPos.transform.position;
        activePos = activeMenuPos.transform.position;

    }

    public void OpenStartMenu(){
        if(startMenu.transform.position == startPos){
            startMenu.SetActive(true);
            ThemeSwap();
            startMenu.GetComponent<subMenuController>().pos = activePos;

            profileMenu.GetComponent<subMenuController>().pos = startPos;
            statsMenu.GetComponent<subMenuController>().pos = startPos;
        }else{
            startMenu.GetComponent<subMenuController>().pos = startPos;
        }
    }

    public void OpenProfileMenu(){
        if(profileMenu.transform.position == startPos){
            startMenu.GetComponent<subMenuController>().pos = startPos;

            profileMenu.SetActive(true);
            ThemeSwap();
            profileMenu.GetComponent<subMenuController>().pos = activePos;

            statsMenu.GetComponent<subMenuController>().pos = startPos;
        }else{
            profileMenu.GetComponent<subMenuController>().pos = startPos;
        }
        
    }

    public void OpenStatsMenu(){
        if(statsMenu.transform.position == startPos){
            startMenu.GetComponent<subMenuController>().pos = startPos;
            profileMenu.GetComponent<subMenuController>().pos = startPos;

            statsMenu.SetActive(true);
            ThemeSwap();
            statsMenu.GetComponent<subMenuController>().pos = activePos;
        }else{
            statsMenu.GetComponent<subMenuController>().pos = startPos;
        }
    }

    public void ExitMenu(){
        Application.Quit();
    }

    public void ThemeSwap(){
        var objs = GameObject.FindGameObjectsWithTag("Menu");
        for( int i = 0; i < objs.Length; i++ ){
            if(objs[i].GetComponent<ThemeComtroller>()){
                objs[i].GetComponent<ThemeComtroller>().SwapTheme();
            }
        }
    }


    public void startX2(){
        SceneManager.LoadScene("Scenes/X2");
    }
    
}
