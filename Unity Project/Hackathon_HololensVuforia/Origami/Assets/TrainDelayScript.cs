using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainDelayScript : MonoBehaviour {

    public GameObject firstDisplay;
    public GameObject secondDisplay;
    private float timer = 0;

    private Text delay1;
    private Text delay2;
    private Color newColor;

    public float ersteMeldung;
    public float zweiteMeldung;
    private bool firstDelay = false;
    private bool secondDelay = false;
    private TrainDelayScript trainDelay;

    // Use this for initialization
    void Start()
    {

        newColor = new Color32(0xB4, 0x00, 0x00, 0xFF);
        delay1 = firstDisplay.GetComponent<Text>();
        delay2 = secondDisplay.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < 55)
        {
            timer += Time.deltaTime;

            if (Mathf.Floor(timer) == ersteMeldung && !firstDelay)
            {
                SetFirstDelay();
                firstDelay = true;
            }
            if (Mathf.Floor(timer) == zweiteMeldung && !secondDelay)
            {
                SetSecondDelay();
                secondDelay = true;
            }
        }
    }

    public void SetFirstDelay()
    {
        delay1.color = newColor;
        delay1.text = "(+1 min)";
       

    }

    public void SetSecondDelay()
    {
        delay2.color = newColor;
        delay1.text = "(+7 min)";
        delay2.text = "(+6 min)";
      
    }

}
