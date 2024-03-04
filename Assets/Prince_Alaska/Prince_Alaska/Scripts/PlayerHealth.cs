using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Check if player health is less than or equal to 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Handle player death here
        // For example, you can reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
