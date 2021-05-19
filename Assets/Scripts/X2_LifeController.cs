using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class X2_LifeController : MonoBehaviour
{
    public Vector3 pos;
    public float body_speed = 1f;
    public GameObject Explosion;
    
    void Start()
    {
        transform.position = pos;
        if(tag != "Menu") Instantiate (Explosion, transform.position, Quaternion.identity);
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, body_speed * Time.deltaTime);
    }
}
