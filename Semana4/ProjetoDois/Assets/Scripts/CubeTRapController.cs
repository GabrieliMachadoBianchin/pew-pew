using UnityEngine;

public class CubeTRapController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) { 
            Destroy(collision.gameObject);        
        }
    }
}
