using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera firstPersonCamera;
    public Camera deathCamera;

   //first frame, even before start
    void Awake()
    {
        firstPersonCamera.enabled = true;
        deathCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input and swap accordingly
        if (Input.GetKeyDown(KeyCode.R))
        {
            firstPersonCamera.enabled = false;
            deathCamera.enabled = true;
        }
        /*if (Input.GetKeyDown(KeyCode.T))  
         {
            firstPersonCamera.enabled = true;
            deathCamera.enabled = false;
        } */
    }
}

