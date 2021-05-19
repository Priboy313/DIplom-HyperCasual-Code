using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gBackMenu : MonoBehaviour
{
     public void Back(){
        SceneManager.LoadScene("Scenes/Main");
    }

}
