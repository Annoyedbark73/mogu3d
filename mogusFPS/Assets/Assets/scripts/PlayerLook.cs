using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour


{
    public GameObject real;
    public float maxUp = -90f;
    public float maxDown = 45f;
    public float mouseSensitivity = 100f;
    public Transform Player;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {

        //temporary code for ragdoll

        var script = real.GetComponent<PlayerLook>();
        script.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

 

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, maxUp, maxDown);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Player.Rotate(Vector3.up * mouseX);

        //temporary code for ragdoll
        if (Input.GetKeyDown(KeyCode.R))
        {
            var script = real.GetComponent<PlayerLook>();
            script.enabled = false;
        }


    }
}
