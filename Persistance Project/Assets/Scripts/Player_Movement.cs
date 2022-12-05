using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public AudioSource footsteps;
    public AudioSource running;
    public CharacterController controller;

    //variables for movement and gravity
    public float moveSpeed = 0.5f;
    public float gravity = -9.81f;

    // variables for player sprint
    public bool isSprinting = false;
    public float sprintMult = 1.2f;

    // variables to check if player is standing on the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    Vector3 oldPos;
    bool isGrounded;

    void Start()
    {
        oldPos = transform.position;
    }

    void Update()
    {
        // check if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // check if player is sprinting
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        } 
        else
        {
            isSprinting = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(oldPos != transform.position && isSprinting == false)
        {
            footsteps.enabled = true;
            running.enabled = false;
        }
        else if(oldPos != transform.position && isSprinting == true)
        {
            running.enabled = true;
            footsteps.enabled = false;
        }
        else
        {
            footsteps.enabled = false;
            running.enabled = false;
        }
        oldPos = transform.position;
        

        // create direction we want to move based on where player is facing
        Vector3 move = transform.right * x + transform.forward * z;

        // move player
        controller.Move(move * moveSpeed * Time.deltaTime);

        // increase speed if sprinting
        if(isSprinting)
        {
            controller.Move((move * sprintMult) * moveSpeed * Time.deltaTime);
        }

        // add gravity to player (probably wont need, but added just in case)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
