using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class BattleScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public EnemyHandler enemyHandler;
    public KeyCode attackKey = KeyCode.Space;
    public XPHandler xpHandler;

    //Fix the damn DMG overflow.
    public void Update()
    {
        if (enemyHandler.enemyHealth == 0)
        {
            if (enemyHandler.enemyAlive == true)
            {
                enemyHandler.enemyAlive = false;
                Debug.Log("The Marauder has been slain");
                xpHandler.XpAllocation();
            }
        }
        else
        {
            if (enemyHandler.enemyHealth <= 0)
            {
                if (enemyHandler.enemyAlive == true)
                {
                    enemyHandler.enemyAlive = false;
                    Debug.Log("The Marauder has been slain");
                    xpHandler.XpAllocation();
                }
            }
        }

        if (playerScript.playerHealth <= 0)
        {
            if (playerScript.playerAlive == true)
            {
                playerScript.playerAlive = false;
                Debug.Log("You have died. Game Over.");
            }
        }

        if (enemyHandler.enemyAlive == false)
        {
            
            
        }
        else
        {
            if (Input.GetKeyDown(attackKey))
            {
                PlayerAttack();
                EnemyAttack();
            }
        }
        
    }

    // I forget why I did pEffectiveDmg but, I believe it was because the math was being weird
    private void PlayerAttack()
    {
        playerScript.pEffectiveDmg = (Mathf.RoundToInt(playerScript.playerDamage * playerScript.playerDamageMult));
        enemyHandler.enemyHealth = enemyHandler.enemyHealth - playerScript.pEffectiveDmg;

    Debug.Log("You attacked the Marauder for:" + playerScript.pEffectiveDmg + " Damage.");

    }

    private void EnemyAttack()
    {
        playerScript.playerHealth = playerScript.playerHealth - enemyHandler.enemyDamage;
        Debug.Log("You were attacked for:" + enemyHandler.enemyDamage + " Damage.");
    }

    private void AttackCheck()
    {
        // something to stop dmg overflow, still keeps happening and idk how to stop it.
    }
}
