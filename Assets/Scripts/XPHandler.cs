using Unity.VisualScripting;
using UnityEngine;

public class XPHandler : MonoBehaviour
{
    public EnemyHandler enemyHandler;
    public PlayerScript playerScript;
    public UIHandler uiHandler;
    public float lvlUpDmgMultiplier = 10f;
    public float lvlUpHpMultiplier = 5f;
    public int lvlUpThreshold = 50;
    
    // Update is checking if enemyAlive & if player xp = threshold
    void Update()
    {
        if(enemyHandler.enemyAlive == false)
        {
            playerScript.playerXp = playerScript.playerXp + enemyHandler.enemyXP;
        }

        if (playerScript.playerXp == lvlUpThreshold)
        {
            LevelUp();
        }
    }

    // Resetting xp to 0, increasing threshold and add new values for player damage and health.
    private void LevelUp()
    {
        playerScript.playerXp = 0;
        playerScript.playerLvl = playerScript.playerLvl + 1;
        playerScript.playerDamageMult = playerScript.playerDamageMult * lvlUpDmgMultiplier;
        playerScript.playerHealth = (int)(playerScript.playerHealth * lvlUpHpMultiplier);
        lvlUpThreshold = lvlUpThreshold + 25;
    } 
}
