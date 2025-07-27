using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullInteraction : MonoBehaviour
{
    [SerializeField] private Image InteractUI;

    private bool interacted;

    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
        InteractUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("f")) && (InteractUI.enabled == true))
        {
            interacted = true;
            InteractUI.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && (!interacted))
        {
            InteractUI.enabled = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Player")) && (!interacted))
        {
            InteractUI.enabled = false;
        }
    }

}
