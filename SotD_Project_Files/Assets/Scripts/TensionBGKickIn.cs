using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensionBGKickIn : MonoBehaviour
{
    [SerializeField] private AudioSource TensionBG;


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TensionBG.Play();
        }
    }

}
