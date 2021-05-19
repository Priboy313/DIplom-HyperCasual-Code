using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Theme", menuName = "Settings/NewTheme")]
public class Themes : ScriptableObject
{
    public int colorNumber = 0;
    public Color[] menu = new Color[5];
    
}
