using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public int speedUpgradeCost = 5;
    public int rangeUpgradeCost = 5;
    public int bulletDistanceUpgradeCost = 5;
    private GameManager gameManager;
    private Turret turret;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        turret = GetComponent<Turret>();
    }

    public void UpgradeSpeed()
    {
        if (gameManager.gold >= speedUpgradeCost)
        {
            gameManager.gold -= speedUpgradeCost;
            turret.cooldown -= 0.5f;
        }
    }

    public void UpgradeRange()
    {
        if (gameManager.gold >= rangeUpgradeCost)
        {
            gameManager.gold -= rangeUpgradeCost;
            turret.range += 2f;
        }
    }

    public void UpgradeBulletDistance()
    {
        if (gameManager.gold >= bulletDistanceUpgradeCost)
        {
            gameManager.gold -= bulletDistanceUpgradeCost;
            turret.projectileSpeed += 2f;
        }
    }
}
