using UnityEngine;

public class AsteroideSpawner : MonoBehaviour
{
    public GameObject asteroids;
    public float timegeneration = 2f;
    public float timeMinG = 0.2f;
    public float interval = 0.05f;
    public float speedMin = 11f;
    public float speedMax = 12f;
    public int nbrAsteroids = 20;
    private float timePass = 0f;
    private float timeTotal = 0f;

    void Update()
    {
        timePass += Time.deltaTime;
        timeTotal += Time.deltaTime;


        float intervalGeneration = Mathf.Max(timeMinG, timegeneration - timeTotal * interval);

        if (timePass > intervalGeneration)
        {
            GenerateAsteroids();
            timePass = 0f;  
        }
    }

    void GenerateAsteroids()
    {
        float xPosition = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
        Vector3 generatePosition = new Vector3(xPosition, Camera.main.orthographicSize + 1f, 0f);

        GameObject newAsteroids = Instantiate(asteroids, generatePosition, Quaternion.identity);

        float speedAleatoire = Random.Range(speedMin, speedMax);

        newAsteroids.transform.Translate(Vector3.down * speedAleatoire * Time.deltaTime);
    }
}