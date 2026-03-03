using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public EnemyHandler enemyHandler;
    public KeyCode attackKey = KeyCode.Space;

    public void Update()
    {
        if (enemyHandler.enemyHealth <= 0)
        {
            enemyHandler.enemyAlive =  false;
        }
        

    }
    
    private void AbilityUsed()
    {
        if (Input.GetKeyDown(attackKey)) // Press atk key do dmg. Later make atk dmg occur so often, atk key = ability.
        {
            enemyHandler.enemyHealth = enemyHandler.enemyHealth - (int)(playerScript.playerDamage * playerScript.playerDamageMult);


        }
        


    }
}
