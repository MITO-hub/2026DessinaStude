using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float speed = 10f;
    public int damage = 1;
    public float lifeTime = 3f;

    private Vector3 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;

        if(moveDirection !=Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
