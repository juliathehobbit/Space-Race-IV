﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Script : MonoBehaviour
{

    public Transform StartingLine;
    public Transform Waypoint1;
    public Transform Waypoint2;
    public Transform Waypoint3;
    public Transform Waypoint4;
    public Transform Waypoint5;
    public Transform Waypoint6;
    public Transform Waypoint7;
    public Transform Waypoint8;
    public Transform Waypoint9;
    public Transform Waypoint10;
    public Transform Waypoint11;
    public Transform Waypoint12;
    public Transform Waypoint13;
    public Transform Finishline;
  
    public Transform currentLoc;
    public Transform nextLoc;
    private Transform[] wayArray;

    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;
    public Vector3 offset;
    public Rigidbody rb;
    private float coolDownTime = 100000f;

    private int currInd = 0;
 
    public int lap = 1;

    void Start(){
       // rb = GetComponent ();
        wayArray = new Transform [15] { StartingLine,Waypoint1, Waypoint2, Waypoint3, 
        Waypoint4, Waypoint5, Waypoint6, Waypoint7, Waypoint8, Waypoint9, Waypoint10, 
        Waypoint11, Waypoint12, Waypoint13, Finishline };
        currentLoc = StartingLine;
        transform.position = currentLoc.position;
        nextLoc = Waypoint1;
        moveShip();
    }

    void Update(){
    //LERP rotation
       Vector3 relativePos = nextLoc.position - transform.position;
       Quaternion toRotation = Quaternion.LookRotation(relativePos);
       transform.rotation = Quaternion.Lerp( transform.rotation, toRotation, rotationSpeed * Time.deltaTime );

    //LERP movement
        Vector3 newPos = nextLoc.position + offset;
        Vector3 smoothPos = Vector3.Lerp (transform.position, newPos, moveSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }

    public void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 9){
            Debug.Log("Hit a waypoint!");
            moveShip();
            StartCoroutine(PauseDuration());
        }
    }

    public void moveShip(){
        //Transform ShipYard = transform.position;

        if(nextLoc == Finishline){
            currentLoc = Finishline;
            if(lap == 1 || lap == 2){
                nextLoc = StartingLine;

            }
        }
        else if (nextLoc == StartingLine){
			gameObject.transform.position = new Vector3(StartingLine.position.x, StartingLine.position.y, StartingLine.position.z);
            currentLoc = StartingLine;
            nextLoc = wayArray[1];
            currInd = 0;
            lap++;
            Debug.Log("NPC just finished lap #" + lap);
        }
        else {
            currentLoc = wayArray[currInd + 1];
            nextLoc = wayArray[currInd + 2];
            currInd++;
            Debug.Log("current index: " + currInd);
        }
        //transform.LookAt (nextLoc);
        Debug.Log("leaving: " + currentLoc + "\n heading towards:" + nextLoc);
    }

    IEnumerator PauseDuration(){
		yield return new WaitForSeconds(coolDownTime);
	}
}
