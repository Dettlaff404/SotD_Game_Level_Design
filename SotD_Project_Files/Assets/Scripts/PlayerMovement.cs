using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement thisPlayerMovement;

    public Transform cam;

    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public Animator playerAnimator;
    private Vector3 moveDir;

    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundMask;
    Vector3 gravityVelocity;
    [SerializeField] bool isGrounded;

    public AudioSource playerWalkingAudio;
    public AudioSource playerRunningAudio;
    public AudioSource playerJumpingAudio;
    public AudioSource cantOpenAudio;
    public AudioSource willWorkAudio;
    public AudioSource pickupAudio;

    public bool gotLockPicker;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (thisPlayerMovement == null)
        {
            thisPlayerMovement = this;
        }

        gotLockPicker = false;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateGravity();
        CheckGrounded();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 18f;
        }
        else
        {
            speed = 6f;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle;

            if (vertical < 0)
            {
                targetAngle = 180 + cam.eulerAngles.y;
            }
            else
            {
                targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            }

            //float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
            if (speed == 18f)
            {
                playerAnimator.SetFloat("Speed", 1f);
            }
            else if (speed == 6f)
            {
                playerAnimator.SetFloat("Speed", 0.1f);
            }
        }
        else
        {
            playerAnimator.SetFloat("Speed", 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerAnimator.SetTrigger("Jump");
            gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Walk") && (!playerWalkingAudio.isPlaying))
        {
            playerWalkingAudio.Play();
            playerRunningAudio.Pause();
            playerJumpingAudio.Stop();
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Running") && (!playerRunningAudio.isPlaying))
        {
            playerRunningAudio.Play();
            playerWalkingAudio.Pause();
            playerJumpingAudio.Stop();
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Jumping") && (!playerJumpingAudio.isPlaying))
        {
            playerJumpingAudio.Play();
            playerWalkingAudio.Pause();
            playerRunningAudio.Pause();
        }

        if ((playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle")) || (Gamemanager.thisGameManager.isPaused == true))
        {
            playerWalkingAudio.Pause();
            playerRunningAudio.Pause();
            playerJumpingAudio.Stop();
        }

    }

    private void UpdateGravity()
    {
        gravityVelocity.y += gravity * Time.deltaTime;
        controller.Move(gravityVelocity * Time.deltaTime);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2;
        }
    }

    
}
