using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 10;
    public float attackRange = 2f;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Player"));

            foreach (Collider2D player in hitPlayers)
            {
                // Check if the player is within attack range
                if (player.CompareTag("Player"))
                {
                    // Attack the player
                    AttackPlayer(player.gameObject);
                    // Set the next attack time based on attack rate
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void AttackPlayer(GameObject player)
    {
        // Deal damage to the player
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }

        // Optionally, trigger attack animation if you have one
        // GetComponent<Animator>().SetTrigger("Attack");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
