using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerHealth = 50;
    public float playerMaxHealth = 50;
    public float playerDamage = 5f;
    public float playerDamageMult = 1f;
    public int playerLvl = 1;
    public int playerXp = 0;
    public bool playerAlive = true;
    public int pEffectiveDmg;
    public bool gameOver = false;
    public int playerArmor = 2;

    public void Update()
    {
        EndCheck();
    }

    public void EndCheck()
    {
        if (playerLvl == 5)
        {
            gameOver = true;
        }
    }
}
