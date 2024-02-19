using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar; // Reference to the UI image representing the health bar
    public float maxHealth = 100f; // Maximum health value
    private float currentHealth; // Current health value

    public Transform player; // Reference to the player's Transform

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
        UpdateHealthBar(); // Update the health bar UI
    }

    void Update()
    {
        // Check if player exists and adjust health bar position based on player's position
        if (player != null)
        {
            RectTransform healthBarRectTransform = healthBar.GetComponent<RectTransform>();
            Vector3 screenPos = Camera.main.WorldToScreenPoint(player.position);
            healthBarRectTransform.position = new Vector3(screenPos.x, screenPos.y, 0f);
        }
    }

    // Function to reduce health
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Reduce current health by damage amount
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // Ensure health doesn't go below 0 or exceed maxHealth
        UpdateHealthBar(); // Update the health bar UI
    }

    // Function to increase health
    public void Heal(float healAmount)
    {
        currentHealth += healAmount; // Increase current health by heal amount
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // Ensure health doesn't exceed maxHealth
        UpdateHealthBar(); // Update the health bar UI
    }

    // Function to update the health bar UI
    void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth; // Calculate fill amount based on current health percentage
        healthBar.fillAmount = fillAmount; // Update the fillAmount property of the Image component
    }
}
