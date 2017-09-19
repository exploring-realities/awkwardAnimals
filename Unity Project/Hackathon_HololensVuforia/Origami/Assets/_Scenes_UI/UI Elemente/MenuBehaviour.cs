using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;


public class MenuBehaviour : MonoBehaviour,  IFocusable
{

    public GameObject ButtonGroup;
    public Material defaultMat;
    public Material onFocusMat;
    public float waitingTime = 2.5f;
    private Animator Anim;
    private Renderer rend;

    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
 
    }
	
    
   public void OnFocusEnter()
    {
        //Debug.Log("MouseOver");

        inFocus();

    }

    public void OnMouseOver()
    {

        inFocus();

    }



    public void OnFocusExit()
    {
        //not implemented

    }

    private void inFocus()
    {
        rend.material = onFocusMat;
        Anim.SetBool("OnFocus", true);
        ButtonGroup.SetActive(true);
    }

    public void ResetMenu()
    {
       // Debug.Log("MouseExit");
        rend.material = defaultMat;
        Anim.SetBool("OnFocus", false);
        ButtonGroup.SetActive(false);
    }

 

}
