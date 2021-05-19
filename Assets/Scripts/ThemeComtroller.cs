using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThemeComtroller : MonoBehaviour
{
    [SerializeField] Themes themes;

    void Start()
    {
        if(this.GetComponent<SpriteRenderer>()){
            this.GetComponent<SpriteRenderer>().color = themes.menu[themes.colorNumber];
        }else if(this.GetComponent<Image>()){
            this.GetComponent<Image>().color = themes.menu[themes.colorNumber];
        }else if(this.GetComponent<Text>()){
            this.GetComponent<Text>().color = themes.menu[themes.colorNumber];
        }
    }

    public void SwapTheme(){
        if(this.GetComponent<SpriteRenderer>()){
            this.GetComponent<SpriteRenderer>().color = themes.menu[themes.colorNumber];
        }else if(this.GetComponent<Image>()){
            this.GetComponent<Image>().color = themes.menu[themes.colorNumber];
        }else if(this.GetComponent<Text>()){
            this.GetComponent<Text>().color = themes.menu[themes.colorNumber];
        }
    }

}
