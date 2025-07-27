using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarSlider : MonoBehaviour
{
    public Slider manaBarSlider;
    public Image fillImageMana;

    private void Awake()
    {
        manaBarSlider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manaBarSlider.value <= manaBarSlider.minValue)
        {
            fillImageMana.enabled = false;
        }

        if ((manaBarSlider.value > manaBarSlider.minValue) && (!fillImageMana.enabled))
        {
            fillImageMana.enabled = true;
        }

        float fillValue = Gamemanager.thisGameManager.currentMana / Gamemanager.thisGameManager.maxMana;
        manaBarSlider.value = fillValue;
    }
}
