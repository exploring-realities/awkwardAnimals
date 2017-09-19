using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScreenPos : MonoBehaviour {

    private Vector3 v3Pos;
    public Camera cam;
    public float posX;
    public float posY;
    public float posZ;

    // Use this for initialization
    void Start()
    {
        v3Pos = new Vector3(posX, posY, posZ);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = cam.ViewportToWorldPoint(v3Pos);
    }
}

