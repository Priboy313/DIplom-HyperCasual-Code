using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/inGameSet")]
public class DataBase : ScriptableObject
{
    public string state;
    public int hpStart;
    public int maxHp;
    public int healScore;
    public int scrapMax;
    public int scrapTact;
}
