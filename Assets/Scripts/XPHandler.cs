using Unity.VisualScripting;
using UnityEngine;

public class XPHandler : MonoBehaviour
{
    public EnemyHandler enemyHandler;
    public PlayerScript playerScript;
    public UIHandler uiHandler;
    public BattleScript BattleScript;
    public float lvlUpDmgMultiplier = 2f;
    public float lvlUpHpMultiplier = 1.5f;
    public int lvlUpThreshold = 10;
    

    // New headache to deal with. Player Max health. Must calculate for LvlUp Values.
    
    // Resetting xp to 0, increasing threshold and add new values for player damage and health.
    public void LevelUp()
    {
        playerScript.playerXp = 0;
        playerScript.playerLvl = playerScript.playerLvl + 1;
        playerScript.playerDamageMult = playerScript.playerDamageMult + lvlUpDmgMultiplier;
        playerScript.playerDamage = playerScript.playerDamage * lvlUpDmgMultiplier;
        playerScript.playerHealth = (int)(playerScript.playerHealth * lvlUpHpMultiplier);
        lvlUpThreshold = lvlUpThreshold + 10;
        Debug.Log("You have Leveled Up to Lvl" + playerScript.playerLvl + "!");
        Debug.Log("Your new stats are; DamageMult: " + playerScript.playerDamageMult );
        Debug.Log("PlayerDamage: " + playerScript.playerDamage );
        Debug.Log("PlayerHealth: " + playerScript.playerHealth );
        Debug.Log("New LvlUp Threshold: " + lvlUpThreshold );
    }

    // New xp check, previous update based approach broke often. Tied to enemy death in Battlescript.
    public void XpAllocation()
    {
        playerScript.playerXp = playerScript.playerXp + enemyHandler.enemyXP;
        if (playerScript.playerXp >= lvlUpThreshold)
        {
            LevelUp();
        }
        Debug.Log("XP Allocation Complete!");
    }
}
