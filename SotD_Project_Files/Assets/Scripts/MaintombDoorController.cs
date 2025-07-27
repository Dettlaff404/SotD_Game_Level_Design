using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaintombDoorController : MonoBehaviour
{
    [SerializeField] private Image openDoorUI;
    [SerializeField] private Animator leverAnimator;
    [SerializeField] private AudioSource leverPullAudio;
    [SerializeField] private GameObject door;

    private Animator doorAnimator;
    private AudioSource doorOpenningAudio;
    [SerializeField] private AudioSource leverLockedAudio;

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
        if ((Input.GetKeyDown("f")) && (openDoorUI.enabled == true) && (Gamemanager.thisGameManager.barCount == 2))
        {
            leverAnimator.SetBool("LeverUp", true);
            doorOpened = true;
            leverPullAudio.Play();
            openDoorUI.enabled = false;
            Invoke("OpenningDoor", 1.2f);
            Invoke("Resetting", 3f);
        }
        else if ((Input.GetKeyDown("f")) && (openDoorUI.enabled == true))
        {
            leverLockedAudio.Play();
            Invoke("CantOpenAudioPlayer", 1f);
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if ((player.CompareTag("Player")) && (!doorOpened))
        {
            openDoorUI.enabled = true;
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

    public void CantOpenAudioPlayer()
    {
        PlayerMovement.thisPlayerMovement.cantOpenAudio.Play();
    }

    private void Resetting()
    {
        Gamemanager.thisGameManager.switchCam = false;
    }
}
