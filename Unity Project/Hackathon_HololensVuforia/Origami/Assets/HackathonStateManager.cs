using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Normal,
    Accessibility
}

public class HackathonStateManager : MonoBehaviour
{

    public State currentState = State.Normal;
    public bool arrowToBeChanged = false;
    public static HackathonStateManager instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

   public void SwitchState()
    {
        if (currentState.Equals(State.Normal))
        {
            currentState = State.Accessibility;
        }
        else
        {
            currentState = State.Normal;
        }
        arrowToBeChanged = !arrowToBeChanged;
    }
}
