using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    // Referenz Gameobjects
    public static GameManagerScript instance;
    public Text scoreText;
    public Text levelText;
    public Text xpText;

    public Text version;

    public Text ScorePopUpText;
    public GameObject ScorePopUpObject;

    public Text XpPopUpText;
    public GameObject XpPopUpObject;

    // Variablen
    public int score;
    private float xp;
    private float xpToLevelUp;
    public int maxLevel = 30;
    public int Level;
    public float xpToLevelUpFactor = 1.25f;

    private bool canlevelUp = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        xpToLevelUp = 50;
        xp = 0;
        score = 0;
        Level = 0;

        version.text = Application.version;

        xpText.text = Mathf.FloorToInt(xp) + " / " + Mathf.FloorToInt(xpToLevelUp);
    }

    public void addScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = "Score: " + score;
        ScorePopUpObject.SetActive(true);
        ScorePopUpText.text = "+" + scoreAmount;
        Invoke("HideScorePopUpObject", 3f);
    }

    public void addXp(int xpAmount)
    {
        xp += xpAmount;

        while (xp >= xpToLevelUp && canlevelUp)
        {
            xp -= xpToLevelUp;
            levelUp();
            xpToLevelUp = xpToLevelUp * xpToLevelUpFactor;

        }

        xpText.text = Mathf.FloorToInt(xp) + " / " + Mathf.FloorToInt(xpToLevelUp);
        XpPopUpObject.SetActive(true);
        XpPopUpText.text = "+" + xp + "XP"; 
        Invoke("HideXpPopUpObject", 3f);
    }

    public void levelUp()
    {
        if (Level < maxLevel && canlevelUp)
        {
            Level++;
        }
        else
        {
            canlevelUp = false;
            Debug.Log("You have already reached Max Level");
        }

        xpToLevelUp *= xpToLevelUpFactor;
        levelText.text = "Level: " + Level;
    }

    public void HideScorePopUpObject()
    {
        ScorePopUpObject.SetActive(false);
    }

    public void HideXpPopUpObject()
    {
        XpPopUpObject.SetActive(false);
    }
}
