using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public string playerName = "Hero";
    public XPHandler xpHandler;
    public PlayerScript playerScript;
    public EnemyHandler enemyHandler;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerLvlText;
    public TextMeshProUGUI playerHpText;
    public TextMeshProUGUI playerXpText;
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyLvlText;
    public TextMeshProUGUI enemyHpText;
    
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       UIValueAssign();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Startup values for UI
    private void UIValueAssign()
    {
        playerNameText.text = playerName;
        playerHpText.text = PlayerHealthAsPercentage() + " % HP";
        playerLvlText.text = "Lvl: " + playerScript.playerLvl;
        playerXpText.text = "Xp: " + playerScript.playerXp;
        enemyNameText.text = "Enemy: " + enemyHandler.enemyName;
        enemyLvlText.text = "Lvl: " + enemyHandler.enemyLevel;
        enemyHpText.text = EnemyHealthAsPercentage() + " % HP";
    }

    private float PlayerHealthAsPercentage()
    {                                                                    
      return (playerScript.playerHealth / playerScript.playerMaxHealth) * 100;
    }
    // Ints are evil. We hate all ints. Useless code. REAL CHAD Devs use only floats and DESTROY your ram.
    private float EnemyHealthAsPercentage()
    {
        return (enemyHandler.enemyHealth / enemyHandler.enemyMaxHealth) * 100;
    }
    
}
