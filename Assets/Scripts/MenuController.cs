using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	[SerializeField] DataBase inGameSet;
	[SerializeField] Profile profile;


	public void X2_noobSet(){
		inGameSet.state = "Noob"; //текущая сложность игры
		profile.GOverController(inGameSet.state); //количество игр на текущей сложности
		inGameSet.hpStart = 5; //количество жизней при старте
		inGameSet.maxHp = 10; //максимальное количество жизней
		inGameSet.healScore = 5; //количество очков, которое необходимо собрать для добавления 1 жизни
		inGameSet.scrapMax = 5; //максимальное количество мусора
		inGameSet.scrapTact = 3; //частота появления нового мусора

	}

	public void X2_midSet(){
		inGameSet.state = "Mid";
		profile.GOverController(inGameSet.state);
		inGameSet.hpStart = 3;
		inGameSet.maxHp = 5;
		inGameSet.healScore = 10;
		inGameSet.scrapMax = 7;
		inGameSet.scrapTact = 2;

	}

	public void X2_proSet(){
		inGameSet.state = "Hard";
		profile.GOverController(inGameSet.state);
		inGameSet.hpStart = 1;
		inGameSet.maxHp = 3;
		inGameSet.healScore = 15;
		inGameSet.scrapMax = 8;
		inGameSet.scrapTact = 1;

	}



}
