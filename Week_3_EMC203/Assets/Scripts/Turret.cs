using UnityEngine;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour
{
    public Transform player; // The player the turret will target
    public GameObject projectilePrefab; // Projectile prefab
    public Transform firePoint; // The point from where projectiles are fired
    public float range = 5f; // Detection range of the turret
    public float firingAngleThreshold = 10f; // Angle within which the turret can fire
    public float cooldown = 2f; // Cooldown time between shots
    public float projectileSpeed = 5f; // Speed of the projectile
    public float restartDistance = 0.5f; // Distance to player at which the scene restarts

    private float lastFireTime = 0f;

    void Update()
    {
        if (player == null) return;

        // Calculate direction and distance to the player
        Vector2 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Check if the player is within range
        if (distanceToPlayer <= range)
        {
            // Rotate the turret to face the player
            RotateTowardsPlayer(directionToPlayer);

            // Check if the player is within the firing angle
            float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer.normalized);
            if (angleToPlayer <= firingAngleThreshold && Time.time >= lastFireTime + cooldown)
            {
                FireProjectile(directionToPlayer.normalized);
                lastFireTime = Time.time;
            }
        }
    }

    private void RotateTowardsPlayer(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void FireProjectile(Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }
}