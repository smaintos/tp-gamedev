using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMove = 12f;
    public float limitXMin = -9f;
    public float limitXMax = 9f;
    public float limitYMin = -5f;
    public float limitYMax = 4f;

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalMove * speedMove * Time.deltaTime);

        float verticalMove = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalMove * speedMove * Time.deltaTime);

        float newPositionX = Mathf.Clamp(transform.position.x, limitXMin, limitXMax);
        float newPositionY = Mathf.Clamp(transform.position.y, limitYMin, limitYMax);

        transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
    }
}