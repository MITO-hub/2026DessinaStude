using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackInterval = 1f;
    public float attackRange = 10f;
    public Transform firePoint;

    private float attackTimer = 0f;
    private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();



    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null && playerHealth.IsDead) return;

        attackTimer += Time.deltaTime;

        if(attackTimer >= attackInterval)
        {
            Transform target = FindNearestEnemy();
            {
                if(target != null)
                {
                    Shoot(target);
                    attackTimer = 0f;
                }
            }
        }
    }
    void Shoot(Transform target)
    {
        Vector3 direction = (target.position - firePoint.position).normalized;

        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.LookRotation(direction)
        );

        Projectile projectile1Script = projectile.GetComponent<Projectile>();

        if (projectile1Script != null)
        {
            projectile1Script.SetDirection(direction);
        }
    }

          Transform FindNearestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            Transform nearest = null;
            float nearestDistance = Mathf.Infinity;

                    foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDistance && distance <= attackRange)
            {
                nearestDistance = distance;
                nearest = enemy.transform;
            }
        }

        return nearest;
        }
}
