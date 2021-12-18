using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    public CharacterController controller;

    public float Speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    bool isGrounded;

    Vector3 velocity;

    // Update is called once per frame
    void Update()

    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask );

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * Speed * Time.fixedDeltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

       /* if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = 8f;
            
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = initSpeed;
            
        } */

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
