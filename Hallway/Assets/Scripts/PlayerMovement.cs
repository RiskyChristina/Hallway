using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -40;
    public float jumpHeight =2f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        /*WalkingButton();
        if (isWalking == true)
        {
            WalkingSound();
        }*/
    }

    /*public AudioSource soundSource;
    private static bool isWalking;

    void WalkingButton()
    {
        // GetKeyDown
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isWalking = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && isGrounded)
        {
            isWalking = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        {
            isWalking = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && isGrounded)
        {
            isWalking = true;
        }

        // GetKeyUp
        if (Input.GetKeyUp(KeyCode.W) && isGrounded)
        {
            isWalking = false;
        }
        if (Input.GetKeyUp(KeyCode.A) && isGrounded)
        {
            isWalking = false;
        }
        if (Input.GetKeyUp(KeyCode.S) && isGrounded)
        {
            isWalking = false;
        }
        if (Input.GetKeyUp(KeyCode.D) && isGrounded)
        {
            isWalking = false;
        }
    }

    void WalkingSound()
    {
        if (isWalking == true)
        {
            audioManager.PlaySound("walkSound");
        }
        if (isWalking == false)
        {
            soundSource.Stop();
        }
    }*/
}
