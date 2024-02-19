using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Reference to the Slider component of the health bar.

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth; // Set the maximum value of the health bar.
        slider.value = maxHealth; // Set the current value to the maximum, indicating full health.
    }

    public void SetHealth(float health)
    {
        slider.value = health; // Set the current value of the health bar.
    }
}
