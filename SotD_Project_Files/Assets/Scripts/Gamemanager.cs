using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager thisGameManager;

    public GameObject pauseScreen;
    public GameObject optionScreen;
    public GameObject pausebtn;
    public GameObject HUDScreen;
    public bool isPaused ;

    public float currentHealth;
    public float maxHealth = 100f;
    public float currentMana;
    public float maxMana = 100f;

    public int barCount;

    public bool takeHealth;
    public bool takeMana;

    [SerializeField] private GameObject MainCam;
    [SerializeField] private GameObject DoorCam;

    public bool switchCam;


    // Start is called before the first frame update
    void Start()
    {
        switchCam = false;

        MainCam.SetActive(true);
        DoorCam.SetActive(false);

        takeHealth = false;
        takeMana = false;

        barCount = 0;

        isPaused = false;

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        if (thisGameManager == null)
        {
            thisGameManager = this;
        }

        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                Resume();
            }
            else if (isPaused == false)
            {
                Pause();
            }
        }

        if (currentMana < 0f)
        {
            currentMana = 0f;
        }

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            Pause();
        }

        if (switchCam == true)
        {
            SwitchCam();
        }
        else
        {
            ResetCam();
        }
        
    }

    private void FixedUpdate()
    {
        HealthReduce();
        ManaReduce();
    }

    public void HealthReduce()
    {
        if (takeHealth == true)
        {
            currentHealth -= 1f;
        }
    }

    public void ManaReduce()
    {
        if (takeMana == true)
        {
            currentMana -= 1f;
        }
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        pauseScreen.SetActive(true);
        pausebtn.SetActive(true);
        HUDScreen.SetActive(false);
        Time.timeScale = 0f;
        
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        optionScreen.SetActive(false);
        pauseScreen.SetActive(false);
        HUDScreen.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Application Quitting");
        Application.Quit();
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("LoadTheData", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void SwitchCam()
    {
        MainCam.SetActive(false);
        DoorCam.SetActive(true);
    }

    public void ResetCam()
    {
        MainCam.SetActive(true);
        DoorCam.SetActive(false);
    }
}
