﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverMapRacerIcon : MonoBehaviour
{
	public Transform racer;
	public GameObject racerIcon;

	public GameObject racerIconText;
	private string racerPlace = "";
	private int racerLap = 1;

	public bool isRacing = false;


    void Start(){
		gameObject.transform.position = new Vector3(racer.position.x, transform.position.y, racer.position.z);
		if (isRacing == true){racerIcon.SetActive(true);}
		else {racerIcon.SetActive(false);}
    }
		
	void Update(){
		gameObject.transform.position = new Vector3(racer.position.x, transform.position.y, racer.position.z);
		UpdateIcon();
    }


	public void UpdateIcon(){
		Text iconTextB = racerIconText.GetComponent<Text>();
		if (racer.gameObject.tag == "Player"){
			racerPlace = racer.gameObject.GetComponent<PlayerController>().PlaceText.text;
			racerLap = racer.gameObject.GetComponent<PlayerController>().lapNum;
			iconTextB.text = "PLAYER: \n Lap #" + racerLap + "\n" + racerPlace;
		}
		else {
			racerLap = racer.gameObject.GetComponent<NPC2Script>().lap;
			iconTextB.text = "Lap #" + racerLap;
		}


	}


}