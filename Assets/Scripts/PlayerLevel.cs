using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

    public int level = 1;
    public int currentXp = 0;
    public int xpToNextLevel = 5;

    public AutoShooter autoShooter;

    public void Addxp(int amount)
    {
        currentXp += amount;

        Debug.Log("XP: " + currentXp + " / " + xpToNextLevel);

        if (currentXp <= xpToNextLevel)
        {
            LevelUP();
        }
    }

    void LevelUP()
    {
        level++;
        currentXp = 0;
        xpToNextLevel += 3;

        Debug.Log("Level Up! Current Level: " + level);

        if (autoShooter != null)
        {
            autoShooter.attackInterval = Mathf.Max(0.2f, autoShooter.attackInterval - 0.1f);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
