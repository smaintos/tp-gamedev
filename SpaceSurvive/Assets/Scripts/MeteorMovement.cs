using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed = 12f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}