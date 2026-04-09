using UnityEngine;

public class xpPick : MonoBehaviour
{
    public int xpAmount = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();

        if (playerLevel != null)
        {
            playerLevel.Addxp(xpAmount);
        }

        Destroy(gameObject);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
