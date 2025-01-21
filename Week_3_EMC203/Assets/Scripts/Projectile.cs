using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f; // Speed of the projectile
    public Transform player; // Reference to the player
    public float detectionRadius = 0.5f; // Distance to restart the scene

    private Vector3 direction;

    // Call this method when instantiating the projectile to set its direction
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized; // Normalize the direction vector
    }

    void Update()
    {
        // Move the projectile in the specified direction
        transform.position += direction * speed * Time.deltaTime;

        // Check the distance to the player
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}