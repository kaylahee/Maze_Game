using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthText;

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthSlider.value = (float)currentHealth / maxHealth;
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
