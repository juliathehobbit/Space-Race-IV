﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

	public static int racePlace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//if (Input.GetKey("escape")) {
		//	Application.Quit ();
		//}
    }
		

	public void Start1(){
		SceneManager.LoadScene("Level1");
	}

	public void Start2(){
		SceneManager.LoadScene("Level2");
	}

	public void Start3(){
		SceneManager.LoadScene("Level3");
	}


	public void WinScreen(){
		SceneManager.LoadScene("EndWin");
	}
		
	public void Restart(){
		SceneManager.LoadScene("MainMenu");

	}

	public void OptionsMenu()
	{
		SceneManager.LoadScene("Options");
	}

	public void Credits(){
		SceneManager.LoadScene("Credits");
	}

	public void Lore()
	{
		SceneManager.LoadScene("LoreNew");
	}

    public void CourseSelect()
    {
        SceneManager.LoadScene("CourseSelect");
    }

    //public void empty02()
    //{
    //	SceneManager.LoadScene("null");
    //}

    public void Quit(){
		Application.Quit();
	}


}
