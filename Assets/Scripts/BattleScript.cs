using UnityEngine;
public class BattleScript : MonoBehaviour
{
    public PlayerScript playerHealth;
    public PlayerScript playerDamage;
    public PlayerScript playerDamageMult;
    public EnemyHandler enemyHealth;
    public EnemyHandler enemyDamage;
    public KeyCode attackKey = KeyCode.Space;
    public EnemyHandler enemyAlive;
    public PlayerScript;

    public void Update()
    {
        enemyHealth.GetComponent<EnemyHandler>();
        playerDamage.GetComponent<PlayerScript>();
        if (enemyHealth <= 0)
        {
            enemyAlive.GetComponent<EnemyHandler>(enemyAlive = false);
           
        }
        

    }
    
    private void AbilityUsed()
    {
        if (Input.GetKeyDown(attackKey)) // Press atk key do dmg. Later make atk dmg occur so often, atk key = ability.
        {
            enemyHealth = enemyHealth - (playerDamage * playerDamageMult);


        }
        


    }
}
