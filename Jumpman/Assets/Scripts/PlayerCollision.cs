using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.onPlay.AddListener(ActivePlayer);
    }

    private void ActivePlayer()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }
        else if (other.transform.CompareTag("Coin"))
        {
            GameManager.Instance.AddScore(10f);
            Destroy(other.gameObject);
        }
    }
}
