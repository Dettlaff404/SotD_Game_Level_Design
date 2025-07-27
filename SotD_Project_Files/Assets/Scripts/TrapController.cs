using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private float Damage = 1f; 

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gamemanager.thisGameManager.currentHealth -= Damage * Time.deltaTime;
        }
    }
}
