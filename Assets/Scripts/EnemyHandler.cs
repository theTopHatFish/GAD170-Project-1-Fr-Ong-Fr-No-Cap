using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public XPHandler xpHandler;
    public PlayerScript playerScript;
    public float enemyHealth = 20;
    public float enemyMaxHealth = 20;
    public int enemyDamage = 5;
    public int enemyXP = 10;
    public int enemyLevel = 1;
    public string enemyName;
    public bool enemyAlive = true;
    private int resurrectionCounter = 0;
    private int resurrectionRandValue;
    private bool victMessageDelivered;
    
    void Start()
    {
        enemyName =  "Marauder";
        Debug.Log("An enemy has appeared! its a: " + enemyLevel + " Lvl Marauder with: " + enemyHealth + " HP!!");
    }

    // The structure of how the enemy resurrects in update (tied to resurrection counter) means
    // incredibly difficult to modify going forward. Maybe could serparate into further functions, unsure
    // at this time.
    void Update()
    {
        if (enemyAlive == true)
        {
        }
        else
        {
            if (playerScript.gameOver == true)
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
//Above code to check resurrection doesn't go higher than 2.
    private void Resurrect()
    {
        resurrectionCounter = resurrectionCounter + 1;
        enemyAlive = true;
        if (resurrectionCounter == 1)
        {
            // The math is screwed. Needs fixing.
            resurrectionRandValue = Random.Range(1,3);
            enemyMaxHealth = enemyMaxHealth + 100 * (resurrectionCounter + 1);
            enemyHealth = enemyMaxHealth;
            enemyDamage = enemyDamage * (resurrectionCounter + 1);
            enemyXP = enemyXP * (resurrectionCounter + 1);
            xpHandler.EnemyLvlCalc(); // Call XpHandler to calculate new enemy lvl.
            Debug.Log("Another enemy has appeared! its a: " + enemyLevel + " Lvl Marauder with: " + enemyHealth + " HP!!");
        }
        else
        {
            enemyMaxHealth = enemyMaxHealth + 100 * (resurrectionCounter + 1 + resurrectionRandValue);
            enemyHealth = enemyMaxHealth;
            enemyDamage = enemyDamage * (resurrectionCounter + 1 + resurrectionRandValue);
            enemyXP = enemyXP * (resurrectionCounter + 1 + resurrectionRandValue);
            xpHandler.EnemyLvlCalc(); 
            Debug.Log("Another enemy has appeared! its a: " + enemyLevel + " Lvl Marauder with: " + enemyHealth + " HP!!");
            // Trying to do basic things like increasing values on lvl up give me appreciation for both
            // how bad I am at math and also how complex some of the calculations under the hood of 
            // a game can be.
        }
    }

    
    private void Victory()
    {
        victMessageDelivered = true;
        Debug.Log("Victory!");
        Debug.Log(
            "You have reached Lvl 5 and have beaten the game, thanks for playing!");
    }
    
}
