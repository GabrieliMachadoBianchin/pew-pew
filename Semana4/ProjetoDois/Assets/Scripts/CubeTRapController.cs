using UnityEngine;

public class CubeTRapController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            AudioSource deathSound = GetComponent<AudioSource>();
            deathSound.Play();
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
            }
            Destroy(collision.gameObject);        
        }
    }
}

