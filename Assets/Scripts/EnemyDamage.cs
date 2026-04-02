using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
public int damage = 1;
public float attackInterval = 1f;

public float attackTimer = 0f;
    void Update()
    {
        attackTimer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (attackTimer < attackInterval) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
        playerHealth.TakeDamage(damage);
        attackTimer = 0f;
        }
    }
}
