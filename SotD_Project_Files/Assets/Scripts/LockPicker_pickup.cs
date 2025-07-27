using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPicker_pickup : MonoBehaviour
{
    [SerializeField] private Image pickupUI;

    private bool picked;

    // Start is called before the first frame update
    void Start()
    {
        pickupUI.enabled = false;
        picked = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("f")) && (pickupUI.enabled == true))
        {
            picked = true;
            PlayerMovement.thisPlayerMovement.gotLockPicker = true;
            PlayerMovement.thisPlayerMovement.pickupAudio.Play();
            this.gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && (!picked))
        {
            pickupUI.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Player")) && (!picked))
        {
            pickupUI.enabled = false;
        } 
    }
}
