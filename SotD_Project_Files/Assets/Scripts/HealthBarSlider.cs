using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    public Slider healthBarSlider;
    public Image fillImageHP;

    private void Awake()
    {
        healthBarSlider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarSlider.value <= healthBarSlider.minValue)
        {
            fillImageHP.enabled = false;
        }

        if ((healthBarSlider.value > healthBarSlider.minValue) && (!fillImageHP.enabled))
        {
            fillImageHP.enabled = true;
        }

        float fillValue = Gamemanager.thisGameManager.currentHealth / Gamemanager.thisGameManager.maxHealth;
        healthBarSlider.value = fillValue;
    }
}
