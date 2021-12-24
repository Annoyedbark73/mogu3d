using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{

    public CharacterController controller;

    public float moveSpeed = 8f;
    public float crouchSpeed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Animator animator;
    

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

        controller.Move(move * moveSpeed * Time.fixedDeltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //big mess for temp animation
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetFloat("Horizontal" , 1f);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetFloat("Horizontal", 0f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetFloat("Horizontal", 1f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetFloat("Horizontal", 0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetFloat("Horizontal", 1f);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetFloat("Horizontal", 0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetFloat("Horizontal", 1f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("Horizontal", 0f);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider bounds)
    {
        Debug.Log("Out Of Bounds!!");
        SceneManager.LoadSceneAsync("TestMap");
        
    }
   
}
