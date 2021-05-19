using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorSwap : MonoBehaviour
{
    [SerializeField] Themes themes;
    public GameObject cam;
    public int ColorNum = 0;

    public void ThemeSwap(){
        themes.colorNumber = ColorNum;

        var objs = GameObject.FindGameObjectsWithTag("Menu");

        for( int i = 0; i < objs.Length; i++ ){
            if(objs[i].GetComponent<ThemeComtroller>()){
                objs[i].GetComponent<ThemeComtroller>().SwapTheme();
            }
        }
        cam.GetComponent<SaveLoad>().SaveGame();
    }
}
