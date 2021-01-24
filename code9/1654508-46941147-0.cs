    public class GameManager : MonoBehaviour {
	public GameObject enemyPrefab;
	public GameObject itemPrefab;
	public GameObject characterPrefab;
	const int enemyCount = 100;
	const int itemCount = 100;
	private GameObjectPool EnemyPool {
		get {
			GameObjectPool pool = ObjectPoolManager.Instance.GetPool<GameObjectPool> (enemyPrefab.name);
			if (pool == null) {
				pool = new GameObjectPool(enemyPrefab, enemyCount);
				ObjectPoolManager.Instance.AddPool(enemyPrefab.name, pool);
			}
			return pool;
		}
	}
	private GameObjectPool ItemPool {
		get {
			GameObjectPool pool = ObjectPoolManager.Instance.GetPool<GameObjectPool> (itemPrefab.name);
			if (pool == null) {
				pool = new GameObjectPool(itemPrefab, itemCount);
				ObjectPoolManager.Instance.AddPool(itemPrefab.name, pool);
			}
			return pool;
		}
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy (1f));
	}
	IEnumerator SpawnEnemy(float t) {
		for (int i = 0; i < enemyCount; ++i) {
			GameObject newEnemy = EnemyPool.Borrow ();
			newEnemy.transform.position = Random.insideUnitSphere;
			yield return new WaitForSeconds (t);
		}
	}
    }
