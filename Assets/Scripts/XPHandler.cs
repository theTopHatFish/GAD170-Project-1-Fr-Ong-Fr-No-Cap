using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class XPHandler : MonoBehaviour
{
    public EnemyHandler enemyHandler;
    public PlayerScript playerScript;
    public UIHandler uiHandler;
    public BattleScript BattleScript;
    public float lvlUpDmgMultiplier = 2f;
    public float lvlUpHpMultiplier = 1.5f;
    public int lvlUpThreshold = 10;
    public bool lvlButtonPress = false;
    public bool multipleInstanceProtection = false;
    public bool lvlUpReady = false;
    public bool lvlUpReadyDelivered = false;

    // New headache to deal with. Player Max health. Must calculate for LvlUp Values.
    // Just kidding , SCREW math.
    public void Update()
    {
        // Probably a very dumb and complicated way of making LevelUp dependant on a button input.
        // ¯\_(ツ)_/¯
        if (lvlUpReady == true && lvlUpReadyDelivered == false)
        {
            Debug.Log("Level Up Ready, Press Space to level up!");
            lvlUpReadyDelivered = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lvlButtonPress = true;
        }
        else
        {
            lvlButtonPress = false;
        }
        if (lvlButtonPress == true && multipleInstanceProtection == true && lvlUpReady == true)
        {
            multipleInstanceProtection = false;
            LevelUp();
            lvlUpReady = false;
        }
       
        
    }

    // Resetting xp to 0, increasing threshold and add new values for player damage and health.
    
    public void LevelUp()
    {
            playerScript.playerXp = playerScript.playerXp - lvlUpThreshold;
            playerScript.playerLvl = playerScript.playerLvl + 1;
            playerScript.playerDamageMult = playerScript.playerDamageMult + lvlUpDmgMultiplier;
            playerScript.playerDamage = playerScript.playerDamage * lvlUpDmgMultiplier;
            playerScript.playerMaxHealth = (int)(playerScript.playerMaxHealth * lvlUpHpMultiplier);
            lvlUpThreshold = lvlUpThreshold + 10;
            playerScript.playerXp = playerScript.playerXp - lvlUpThreshold;
            playerScript.playerHealth = playerScript.playerMaxHealth;
            Debug.Log("You have Leveled Up to Lvl" + playerScript.playerLvl + "!");
            Debug.Log("Your new stats are; DamageMult: " + playerScript.playerDamageMult );
            Debug.Log("PlayerDamage: " + playerScript.playerDamage );
            Debug.Log("PlayerHealth: " + playerScript.playerHealth );
            Debug.Log("New LvlUp Threshold: " + lvlUpThreshold );
    }

    // New xp check, previous update based approach broke often. Tied to enemy death in Battlescript.
    public void XpAllocation()
    {
        multipleInstanceProtection = true;
        playerScript.playerXp = playerScript.playerXp + enemyHandler.enemyXP;
        if (playerScript.playerXp >= lvlUpThreshold)
        {
            lvlUpReady = true;
        }
        Debug.Log("XP Allocation Complete!");
        lvlUpReadyDelivered = false;
    }

    public void EnemyLvlCalc()
    {
        enemyHandler.enemyLevel = enemyHandler.enemyLevel + (enemyHandler.enemyXP / 10);
    }
    
}
