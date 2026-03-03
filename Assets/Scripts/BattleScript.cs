using UnityEngine;
using UnityEngine.InputSystem;
public class BattleScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public EnemyHandler enemyHandler;
    public KeyCode attackKey = KeyCode.Space;

    public void Update()
    {
        if (enemyHandler.enemyHealth <= 0)
        {
            enemyHandler.enemyAlive = false;
            Debug.Log("The Marauder has been slain");
        }

        if (playerScript.playerHealth <= 0)
        {
            playerScript.playerAlive = false; 
            Debug.Log("You have died. Game Over.");
        }

        if (Input.GetKeyDown(attackKey))
        {
            PlayerAttack();
            EnemyAttack();
        }
        
    }

    private void PlayerAttack()
    {
        enemyHandler.enemyHealth =
            enemyHandler.enemyHealth - (int)(playerScript.playerDamage * playerScript.playerDamageMult);
        Debug.Log("You attacked the Marauder for:" + playerScript.playerHealth + "Damage.");

    }

    private void EnemyAttack()
    {
        playerScript.playerHealth = playerScript.playerHealth - enemyHandler.enemyDamage;
        Debug.Log("You were attacked for:" + enemyHandler.enemyDamage + "Damage.");
    }
}
