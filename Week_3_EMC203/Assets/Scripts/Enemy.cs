using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform startLocation;
    public Transform endLocation;
    public float speed = 2f;
    public bool useCubicMovement;

    private float progress = 0f;

    void Update()
    {
        progress += speed * Time.deltaTime;
        float t = useCubicMovement ? EaseOutCubic(progress) : EaseOutQuadratic(progress);
        transform.position = Vector3.Lerp(startLocation.position, endLocation.position, t);

        if (progress >= 1f)
        {
            FindFirstObjectByType<GameManager>()?.DecreaseHP();
            Destroy(gameObject);
        }
    }

    float EaseOutQuadratic(float x) => 1 - (1 - x) * (1 - x);
    float EaseOutCubic(float x) => 1 - Mathf.Pow(1 - x, 3);
}
