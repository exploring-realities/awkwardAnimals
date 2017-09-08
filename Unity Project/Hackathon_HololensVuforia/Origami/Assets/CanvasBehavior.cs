using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;


public class CanvasBehavior : MonoBehaviour, IFocusable { 


    private MenuBehaviour menuScript;
	

	void Start () {
        menuScript = GameObject.FindObjectOfType<MenuBehaviour>();

    }

    public void OnFocusEnter()
    {
        //not implemented

    }



    public void OnMouseExit()
    {
        //Debug.Log("MouseExit");

        menuScript.ResetMenu();

    }


    public void OnFocusExit()
    {
       //Debug.Log("MouseExit");

        menuScript.ResetMenu();

    }



}
