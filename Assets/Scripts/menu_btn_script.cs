using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_btn_script : MonoBehaviour
{
    public Button continue_btn;
    public Button load_btn;
    public AudioSource btn_Click;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("isSaveData") == 1)
        {
            continue_btn.interactable = true;
            load_btn.interactable = true;
        }
        else
        {
            continue_btn.interactable = false;
            load_btn.interactable = false;
        }
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("LoadTheData", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    
}
