using UnityEngine;

public class CanonController : MonoBehaviour
{
    
    public GameObject projectilePrefab; // Arraste a Esfera aqui
    public Transform spawnPoint;        // Local de onde sai o tiro
    public float fireRate = 2.0f;       // Tempo entre tiros
    public float force = 10f;

    
        void Start()
        {
            if (spawnPoint == null)
            {
                GameObject go = new GameObject("GeneratedSpawnPoint");
                go.transform.SetParent(this.transform);

                float offsetZ = GetComponent<Collider>().bounds.extents.z;

                go.transform.localPosition = new Vector3(0, 0, offsetZ + 0.5f);
                spawnPoint = go.transform;
            }

            InvokeRepeating("Shoot", 1.0f, fireRate);
        }
    

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Rigidbody>().linearVelocity = -spawnPoint.forward * force;

        Destroy(projectile, 5.0f);
    }

}
