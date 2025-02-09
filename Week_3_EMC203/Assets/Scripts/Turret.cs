using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float range = 5f;
    public float firingAngleThreshold = 10f;
    public float cooldown = 2f;
    public float projectileSpeed = 5f;
    private float lastFireTime = 0f;

    void Update()
    {
        if (player == null) return;

        Vector2 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        RotateTowardsPlayer(directionToPlayer);

        if (distanceToPlayer <= range)
        {
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

    private void FireProjectile(Vector3 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetDirection(direction);
    }
}
