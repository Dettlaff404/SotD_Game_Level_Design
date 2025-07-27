using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicsController : MonoBehaviour
{
    [SerializeField] private GameObject cinematicsUI;

    private bool isPlayed;

    // Start is called before the first frame update
    void Start()
    {
        isPlayed = false;
        cinematicsUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && (!isPlayed))
        {
            isPlayed = true;
            cinematicsUI.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Gamemanager.thisGameManager.isPaused = true;
        }
    }

    public void CinematicContinue()
    {
        cinematicsUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Gamemanager.thisGameManager.isPaused = false;
    }
}
