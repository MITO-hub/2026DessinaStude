using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

public float  minX = -14f;
public float maxX = 14f;
public float minZ = -14;
public float maxZ = 14;

private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth != null && playerHealth.IsDead) return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0f, z).normalized;

        Vector3 nextPosition = transform.position + moveDir * moveSpeed * Time.deltaTime;

        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        nextPosition.z = Mathf.Clamp(nextPosition.z, minZ, maxZ);

        transform.position = nextPosition;

        if(moveDir != Vector3.zero)
        {
            transform.forward = moveDir;
        }
    }
}
