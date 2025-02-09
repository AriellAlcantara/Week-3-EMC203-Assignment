using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public int playerHP = 10;
    public int gold = 0;

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("Gold: " + gold);
    }

    void Start()
    {
        UpdateHPUI();
    }

    public void DecreaseHP()
    {
        playerHP--;
        UpdateHPUI();

        if (playerHP <= 0)
        {
            ShowGameOverScreen();
        }
    }

    private void UpdateHPUI()
    {
        hpText.text = "HP: " + playerHP;
    }

    private void ShowGameOverScreen()
    {
        Debug.Log("Game Over!");
        // Implement UI logic for failure screen
    }
}
