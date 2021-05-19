using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    [SerializeField] Profile profile;

    public InputField Input;
    public GameObject nString;

    private void Start() {
        Input.text = profile.Nickname;
    }

    public void Change(){
        profile.Nickname = Input.text;
        nString.GetComponent<Text>().text = Input.text;
    }

}
