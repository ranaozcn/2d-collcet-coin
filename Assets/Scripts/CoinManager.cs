using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.AddScore(1);
            gameObject.SetActive(false);
        }
    }
}
