using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class clockScript : MonoBehaviour {

    private Text timeDisplay;
    private int _minutes;
    private int _hours;

    // Use this for initialization
    void Start () {

        timeDisplay = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {

        DateTime time = DateTime.Now;
         
       timeDisplay.text = time.Hour.ToString() + ":" + time.Minute.ToString();
    }
}
