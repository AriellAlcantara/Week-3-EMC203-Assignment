using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector
    public float lifeTime = 5f; // Time before the projectile is destroyed

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Check distance to the player
        if (player != null && Vector2.Distance(transform.position, player.position) <= 0.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the scene
        }
    }
}