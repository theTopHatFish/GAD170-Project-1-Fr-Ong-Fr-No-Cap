using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public float enemyHealth = 20;
    public float enemyMaxHealth = 20;
    public int enemyDamage = 5;
    public int enemyXP = 10;
    public int enemyLevel = 1;
    public string enemyName = "Marauder";
    public bool enemyAlive = true;
    private int resurrectionCounter = 0;
    private int resurrectionRandValue;
    private bool victMessageDelivered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAlive == true)
        {
        }
        else
        {
            if (resurrectionCounter == 2)
            {
                if(victMessageDelivered==true)
                { 
                }
                else
                {
                    Victory();
                }
            }
            else
            {
                Resurrect();
            }
        }
    }
//"Spawns" more enemies (Im lazy) up to twice (As per assignment outline).
//Tracks these "Spawns" (Resurrections) via resurrectionCounter.
//Then uses that to increase the enemy stat values. Rand value to multiply final resurrect stats (Boss)
//Above code to check resurrection doesn't go higher than 2
    private void Resurrect()
    {
        resurrectionCounter = resurrectionCounter + 1;
        enemyAlive = true;
        Debug.Log("Another enemy has appeared!");
        if (resurrectionCounter == 1)
        {
            // The math is screwed. Needs fixing.
            resurrectionRandValue = Random.Range(1,3);
            enemyHealth = enemyHealth + 100 * (resurrectionCounter + 1);
            enemyDamage = enemyDamage * (resurrectionCounter + 1);
            enemyXP = enemyXP * (resurrectionCounter + 1);
        }
        else
        {
            Debug.Log("It's a larger and meaner looking Marauder... He is the boss!");
            enemyHealth = enemyHealth + 100 * (resurrectionCounter + 1 + resurrectionRandValue);
            enemyDamage = enemyDamage * (resurrectionCounter + 1 + resurrectionRandValue);
            enemyXP = enemyXP * (resurrectionCounter + 1 + resurrectionRandValue);
        }
    }

    private void Victory()
    {
        victMessageDelivered = true;
        Debug.Log("Victory!");
        Debug.Log(
            "The Boss, the final marauder now lies beneath your feet. You have beaten the game, thanks for playing!");
    }
    
}
