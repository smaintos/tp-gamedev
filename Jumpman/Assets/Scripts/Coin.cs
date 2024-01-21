using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Le joueur a ramass� le coin, ajoutez +10 au score
            GameManager.Instance.currentScore += 10;
            // D�sactivez le GameObject du coin pour le faire dispara�tre
            gameObject.SetActive(false);
        }
    }
}
