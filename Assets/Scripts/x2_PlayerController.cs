using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class x2_PlayerController : MonoBehaviour
{

    [SerializeField] DataBase inGameSet; //ассет с настройками
    [SerializeField] Profile profile;

    public GameObject gameStats; //экран смерти

    public GameObject goal1; //верхняя точка
    public GameObject goal2; //нижняя точка
    public GameObject Explosion; // эффект разрушения из партиклов
    public GameObject ScoreText; //внешний счётчик очков
    public GameObject ComboText; //внешний счётчик комбо
    public GameObject DeathText; //внешний счётчик смертей
    public GameObject scrapController;
    public int score = 0; //внутренний счётчик очков
    public int combo = 0; //внутренний счётчик последовательного сбора целей
    public int death = 0; //внутренний счётчик смертей

    public float body_speed = 2f; //скорость игрока
    public float body_rotation = 1f; //скорость поворота игрока
    public bool check = false; // флаг направления

    public int hp; // жизни игрока
    public GameObject[] hpArr = new GameObject[10]; // массив хп
    public GameObject hpXY; // маркер для хп-очков
    public GameObject hpBody; // префаб хп
    public float Wmax = 5f; // максимальная ширина хп-бара
    public float Wobj = 0.6f; // ширина спрайта одного хп
    private Vector3 g1pos;
    private Vector3 g2pos;

    void Start(){
        hp = inGameSet.hpStart;
        //активация верхней и деактивация нижней точки, присваивание случайных координат
        g1pos = new Vector3(Random.Range(-2.7f,2.7f), goal1.transform.position.y, 1);
        g2pos = new Vector3(Random.Range(-2.7f,2.7f), goal2.transform.position.y, 1);

        goal1.transform.position = g1pos;
        goal1.SetActive (true);
        goal2.transform.position = g2pos;
        goal2.SetActive (false);

        //установка стартовой позиции игрока в координаты неактивной точки
        var start_g2pos = goal2.transform.position;
        transform.position = new Vector3(start_g2pos.x, start_g2pos.y, 2f);

        hpControler("Start"); //вызов функции отрисовки хп-бара
        scrapController.GetComponent<ScrapSpawner>().ScrapSpawn(); //вызов спавнера мусора

        //управление экраном смерти
        gameStats.GetComponent<subMenuController>().pos = gameStats.GetComponent<DeadMenucontroller>().startPos.transform.position;
    }


    void Update(){
        //при достижении координат неактивной цели - сменить направление
        if(transform.position == goal1.transform.position || transform.position == goal2.transform.position) check = !check;

        //Движение тела, цель жёстко закреплена координатами выбранной или активной цели
        if(!check) {
            transform.position = Vector3.MoveTowards(transform.position, goal1.transform.position, body_speed * Time.deltaTime);
        } else
        if(check) {
            transform.position = Vector3.MoveTowards(transform.position, goal2.transform.position, body_speed * Time.deltaTime);
        }
        transform.rotation *= Quaternion.Euler(0f,0f,body_rotation);
    }

        //действия при достижении координат одной из точек, смена выбранной позиции, увеличение счёта очков
    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "goal1"){

            goal1.SetActive (false);

            goal2.SetActive (true);
            g2pos = new Vector3(Random.Range(-2.7f,2.7f), goal2.transform.position.y, 1);
            goal2.transform.position = g2pos;

        }else if(other.gameObject.tag == "goal2"){

            goal1.SetActive (true);
            g1pos = new Vector3(Random.Range(-2.7f,2.7f), goal1.transform.position.y, 1);
            goal1.transform.position = g1pos;
            
            goal2.SetActive (false);
        }

        //отрисовка на сцене и добавление очков в статистику
        score++;
        ScoreText.GetComponent<Text>().text = "" + score;
        gameStats.GetComponent<DeadMenucontroller>().score = score;
        profile.ScoreController(inGameSet.state);

        //отрисовка на сцене и добавление в статистику текущего комбо
        combo++;
        ComboText.GetComponent<Text>().text = "x" + combo;
        gameStats.GetComponent<DeadMenucontroller>().ComboController(combo);
        profile.ComboController(inGameSet.state, combo);
        

            //прибавка одного очка жизни, если собрано необходимое количество целей и не достигнут лимит
        double ost = score % inGameSet.healScore;
        if(ost == 0 && hp != inGameSet.maxHp){
            hp++;
            hpControler("Plus");
        }

        scrapController.GetComponent<ScrapSpawner>().ScrapSpawn(); //вызов спавнера мусора
       
    }// onCollision

    


        //при столкновении с мусором: изменить направление вращения, отнять 1 жизнь, вызвать функцию отрисовки и рассчёта жизней и шкалы
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Scrap"){
            body_rotation *= -1;

                hp--;
                hpControler("Minus");

                combo = 0;
                ComboText.GetComponent<Text>().text = "x" + combo;
                
                death++;
                DeathText.GetComponent<Text>().text = "" + death;
                gameStats.GetComponent<DeadMenucontroller>().death = death;
                profile.DeathController(inGameSet.state);

            if(hp == 0){
                Instantiate(Explosion, transform.position, Quaternion.identity);
                goal1.SetActive(false);
                goal2.SetActive(false);
                gameObject.SetActive(false);
                
                gameStats.SetActive(true);
                gameStats.GetComponent<DeadMenucontroller>().Death();
                gameStats.GetComponent<subMenuController>().pos = gameStats.GetComponent<DeadMenucontroller>().activePos.transform.position;
                body_speed = 0;
                
            }   
        }
    }

        //отрисовка спрайтов каждого очка жизни
    public void hpControler(string state){

            //вызывается при первой загрузке сцены
        if(state == "Start"){
            for(int i = 0; i < hp; i++){

                hpArr[i] = GameObject.Instantiate(hpBody) as GameObject;
                hpCalc(i);
                
            }
        } else if(state == "Minus"){ //вызывается при потере жизни

            Instantiate (Explosion, hpArr[hp].transform.position, Quaternion.identity);
            Destroy(hpArr[hp]);

            for(int i = 0; i < hp; i++){
                hpCalc(i);
            }
        } else if(state == "Plus"){ //вызывается при добавлении жизни

            hpArr[hp-1] = GameObject.Instantiate(hpBody) as GameObject;
            for(int i = 0; i < hp; i++){
                hpCalc(i);
            }
        }

    }

        //рассчёт позиция для кардого спрайта жизни
    public void hpCalc(int i){
            
        var Wspace = Wmax - Wobj * hp; // оставшееся свободное пространсво
        var LWspace = Wspace/hp; //свободное пространство каждого спрайта хп(сумма боковых отступов)
        var OMspace = Wobj + LWspace; //сколько занимает один спрайт с отступами
        var Bobj = OMspace/2; // боковой отступ каждого

            var pos = new Vector3(hpXY.transform.position.x + (i * OMspace) + Bobj, hpXY.transform.position.y, 5);

            hpArr[i].GetComponent<X2_LifeController>().pos = pos;

    }

    //изменение направления по нажатию на кнопку
    public void mov_change(){
        check = !check;
    }



}
