using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public static ChestController thisChestController;

    [SerializeField] Image openChest_UI;

    [SerializeField]  Animator chestAnimator;

    [SerializeField] AudioSource chestOpenAudio;

    bool chestClosed = true;


    // Start is called before the first frame update
    void Start()
    {
        if (thisChestController == null)
        {
            thisChestController = this;
        }

        chestAnimator = this.GetComponent<Animator>();

        openChest_UI.enabled = false;   
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") && (chestClosed))
        {
            openChest_UI.enabled = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            openChest_UI.enabled = false;
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown("f")) && (openChest_UI.enabled == true))
        {
            chestAnimator.SetTrigger("OpenChest");
            chestOpenAudio.Play();
            chestClosed = false;
            openChest_UI.enabled = false;
        }
    }


}
