using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class subMenuController : MonoBehaviour
{
    public GameObject startPos;
    public Vector3 pos;
    public float body_speed = 50f;

    
    void Start()
    {
        pos = startPos.transform.position;
        transform.position = pos;
    }

    
    void Update()
    {
        if(transform.position == startPos.transform.position && pos == startPos.transform.position){
            gameObject.SetActive(false);
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, body_speed * Time.deltaTime);
    }
}
