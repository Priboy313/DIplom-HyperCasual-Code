using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class x2_ScrapController : MonoBehaviour
{
    public GameObject start_max; // маркер стартовой позиции, высшая координата
        public GameObject start_min; // маркер стартовой позиции, низшая координата
        public GameObject finish; // объект телепортации на стартовую позицию
        public GameObject Explosion; // система партиклов при уничтожении
    private float body_speed; // скорость перемещения
        public float max_body_speed; // максимально возможная скорость перемещения
        public float min_body_speed; // минимально возможная скорость перемещения

    private float body_rotation; // скорость вращения
        public float max_body_rotation; // максимально возможная скорость вращения
        private float min_body_rotation; // минимальной возможная скорость вращения

    private float xstart;
    private float ystart;
    private Vector3 pos;


    void Start()
    {
        min_body_rotation = max_body_rotation * (-1); // максимальная скорость обратного вращения
   
        BodyXY();
        transform.position = new Vector3(xstart, ystart, 0f);
        BodySpeed();
        BodyRotation();
    }

    void BodyXY(){//рандомные координаты - стартовая позиция по маркерам
        xstart = Random.Range(start_min.transform.position.x - 10, start_min.transform.position.x);
        ystart = Random.Range(start_min.transform.position.y, start_max.transform.position.y);

        pos = new Vector3(finish.transform.position.x + 5, ystart, transform.position.z);
    }
    void BodySpeed(){ // скорость мусора
        body_speed = Random.Range(min_body_speed, max_body_speed);
    }

    void BodyRotation(){ // в какую сторону будет крутиться мусор
        body_rotation = Random.Range(min_body_rotation, max_body_rotation);
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, body_speed * Time.deltaTime);

        transform.rotation *= Quaternion.Euler(0f,0f,body_rotation); // вращение себя
    }


    private void OnTriggerEnter2D(Collider2D other) {
        BodyXY();

        if(other.gameObject.tag == "Finish"){ // при достижении границы уровня переопределить скорости и переместиться в начало

            transform.position = new Vector3(xstart, ystart, 0f);
            BodySpeed();
            BodyRotation();

        }else if(other.gameObject.tag == "Player"){ // при столкновении с игроком вызвать эффект уничтожения, вернуться на исходную и переопределить скорости
            Instantiate (Explosion, transform.position, Quaternion.identity);

            transform.position = new Vector3(xstart, ystart, 0f);
            BodySpeed();
            BodyRotation();
        }
    }

}
