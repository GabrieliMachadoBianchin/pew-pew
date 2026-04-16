using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {

            FindFirstObjectByType<GameManager>().AdicionarMorteInimigo();
            /*
            ScoreManager sm = Object.FindFirstObjectByType<ScoreManager>();
            if (sm != null)
            {
                sm.AddEnemyKill(100);
            }*/

            Destroy(collision.gameObject);

            float randomx = UnityEngine.Random.Range(-15, 15);
            float randomz = UnityEngine.Random.Range(-15, 15);

            GameObject enemyPrefab = Resources.Load<GameObject>("Enemy");
            if (enemyPrefab != null)
            {
                GameObject newEnemy = Instantiate(enemyPrefab);
                newEnemy.transform.position = new Vector3(randomx, 1, randomz);
                newEnemy.transform.rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);
            }
        }

        Destroy(gameObject);
    }
}
