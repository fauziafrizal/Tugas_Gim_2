using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageCooldown = 1f;

    private float damageTimer;

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            damageTimer += Time.deltaTime;

            if(damageTimer >= damageCooldown)
            {
                PlayerHealth playerHealth =
                    collision.GetComponent<PlayerHealth>();

                if(playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }

                damageTimer = 0f;
            }
        }
    }
}