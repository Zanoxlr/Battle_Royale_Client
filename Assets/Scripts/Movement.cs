using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{/*
    public float sensitivity = 3f;
    private float yRotation;
    private float xRotation;
    private float speed;
    float x;
    float z;
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float crouchSpeed = 3.5f;
    public bool isDead;
    public CharacterController controller;
    private float gravity = -10f;
    public float groundDistance = 3f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;
    Vector3 velocity;
    bool isGrounded;
    bool isCrouching;
    bool jumped;
    Vector3 move;
    public AudioClip jumpingSoud;
    public AudioClip landingSound;
    public AudioClip movingSound1;
    public AudioClip movingSound2;
    private AudioClip[] movingSoundsArray;
    public Camera camMain;
    void Start()
    {
        //Disable cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        movingSoundsArray = new AudioClip[] { movingSound1, movingSound2 };
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //Landing sound
        if(isGrounded == true && velocity.y == 0)
        {
            AudioSource.PlayClipAtPoint(landingSound, transform.position);
        }

        if (isDead == false)
        {
            //Mouse look
            yRotation += Input.GetAxis("Mouse X") * sensitivity;
            xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            camMain.transform.rotation = Quaternion.Euler(xRotation, 0, 0);
            //Movement
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            move = new Vector3(
                transform.right.x * x + transform.forward.x * z,
                0,
                transform.right.z * x + transform.forward.z * z
                );
            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            //Jumping
            if (Input.GetAxis("Jump") == 1 && isGrounded == true)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -1.3f * gravity);
                if (jumped == false) 
                { 
                    StartCoroutine(JumpSoundMethod());
                    jumped = true;
                }
            }
            //Run and walk speed 
            if (Input.GetAxis("Sprint") != 0)
            {
                speed = runSpeed;
            }
            //Crouching
            else if (Input.GetAxis("Crouching") != 0 && isGrounded == true)
            {
                transform.localScale = new Vector3(1, 0.7f, 1);
                speed = crouchSpeed;
                isCrouching = true;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                speed = walkSpeed;
                isCrouching = false;
            }
            //Playing walking sounds
            if(velocity.x != 0 && velocity.z != 0)
            {
                AudioSource.PlayClipAtPoint(movingSound1, transform.position);
            }
        }
    }
    public void Die()
    {
        isDead = true;
    }
    IEnumerator JumpSoundMethod()
    {
        AudioSource.PlayClipAtPoint(jumpingSoud, transform.position);
        yield return new WaitForSeconds(jumpingSoud.length + 0.1f);
        jumped = false;
    }*/
}
