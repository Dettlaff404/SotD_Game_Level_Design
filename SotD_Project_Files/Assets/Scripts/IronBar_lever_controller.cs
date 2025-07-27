using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronBar_lever_controller : MonoBehaviour
{
    [SerializeField] private Image openDoorUI;
    [SerializeField] private Animator leverAnimator;
    [SerializeField] private AudioSource leverPullAudio;
    [SerializeField] private GameObject door;

    private Animator doorAnimator;
    private AudioSource doorOpenningAudio;

    bool doorOpened;

    // Start is called before the first frame update
    void Start()
    {
        openDoorUI.enabled = false;
        doorOpened = false;
        doorAnimator = door.GetComponent<Animator>();
        doorOpenningAudio = door.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("f")) && (openDoorUI.enabled == true))
        {
            leverAnimator.SetBool("LeverUp", true);
            doorOpened = true;
            leverPullAudio.Play();
            openDoorUI.enabled = false;
            Gamemanager.thisGameManager.barCount += 1;
            Invoke("OpenningDoor", 1.2f);
            Invoke("Resetting", 3f);
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if ((player.CompareTag("Player")) && (!doorOpened))
        {
            openDoorUI.enabled = true;
            if (!PlayerMovement.thisPlayerMovement.willWorkAudio.isPlaying)
            {
                PlayerMovement.thisPlayerMovement.willWorkAudio.Play();
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if ((player.CompareTag("Player")) && (!doorOpened))
        {
            openDoorUI.enabled = false;
        }
    }

    private void OpenningDoor()
    {
        doorAnimator.SetTrigger("OpenDoor");
        doorOpenningAudio.Play();
        Gamemanager.thisGameManager.switchCam = true;
    }

    private void Resetting()
    {
        Gamemanager.thisGameManager.switchCam = false;
    }
}
