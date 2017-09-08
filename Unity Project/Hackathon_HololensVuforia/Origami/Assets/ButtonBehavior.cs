using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;


public class ButtonBehavior : MonoBehaviour
{

   

    [Range(0f, 2)] public float scaleFactor = 1.3f;
    [Range(0f, 2)] public float resizeDuration = 0.3f;
    private Vector3 initialScale;
    private Vector3 targetScale;
    private Vector3 startScale;

    // Use this for initialization
    void Start()
    {
        initialScale = transform.localScale;
    }

    public void OnInputClicked(InputEventData eventData)
    {
        Debug.Log("Selected");
       
    }



   //public void OnGazeEnter()
   public void InFocus()
    {
        GetComponent<Button>().OnPointerEnter(null);
        //Debug.Log("Pointer Enter");
        startScale = transform.localScale;
        targetScale = transform.localScale * scaleFactor;
        StartCoroutine("reSizeButton");
    }

   public void LostFocus()
    //public void OnGazeLeave()
    {
        //Debug.Log("Pointer Leave");
        startScale = transform.localScale;
        targetScale = initialScale;
        StartCoroutine("reSizeButton");
    }


  

    IEnumerator reSizeButton()
    {
        for (float t = 0; t < 1; t += Time.deltaTime / resizeDuration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);

            yield return null;
        }
    }
}