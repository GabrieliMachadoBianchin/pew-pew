using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        float randomx = UnityEngine.Random.Range(-15, 15);
        float randomz = UnityEngine.Random.Range(-15, 15);

        GameObject enemy = (GameObject)Instantiate(Resources.Load("Enemy", typeof(GameObject)));

        enemy.transform.position = new Vector3(randomx, 1, randomz );

        enemy.transform.rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);

        Destroy(gameObject);
    }
}
