using UnityEngine;

public class WallDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If the player touches the wall, call the Die method of the PlayerHealth script
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Die();
            }
        }
    }
}
