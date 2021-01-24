    public class AddHandgunAmmo : MonoBehaviour
    {
        private EnemyDrops enemyDrops;
        private void Awake()
        {
            enemyDrops = FindObjectOfType<EnemyDrops>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == string.Format("Player"))
            {
              enemyDrops.AddHandgunAmmo(50);
                Destroy(gameObject);
            }
        }
    } 
