using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodenDoor_controller : MonoBehaviour
{
    [SerializeField] private Image lockpickUI;
    [SerializeField] private Image lockedUI;
    private AudioSource doorOpeningAudio;
    private Animator doorAnimator;

    private bool isDoorOpened;

    // Start is called before the first frame update
    void Start()
    {
        lockpickUI.enabled = false;
        lockedUI.enabled = false;
        isDoorOpened = false;

        doorOpeningAudio = this.GetComponent<AudioSource>();
        doorAnimator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("e")) && (lockpickUI.enabled == true) )
        {
            doorOpeningAudio.Play();
            doorAnimator.SetTrigger("OpenDoor");
            lockpickUI.enabled = false;
            isDoorOpened = true;
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (PlayerMovement.thisPlayerMovement.gotLockPicker)
        { 
            if ((player.CompareTag("Player")) && (!isDoorOpened))
            {
                lockpickUI.enabled = true;
            }
        }
        else
        {
            if ((player.CompareTag("Player")) && (!isDoorOpened))
            {
                lockedUI.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (PlayerMovement.thisPlayerMovement.gotLockPicker)
        {
            if ((player.CompareTag("Player")) && (!isDoorOpened))
            {
                lockpickUI.enabled = false;
            }
        }
        else
        {
            if ((player.CompareTag("Player")) && (!isDoorOpened))
            {
                lockedUI.enabled = false;
            }
        }
    }
}
