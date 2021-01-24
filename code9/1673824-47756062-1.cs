    public class Spawner : MonoBehaviour 
    {
        public Transform player;
        public Transform prefab;
    
        [Range(10,50)]
        public float distance = 20f;
    
    
        IEnumerator Start()
        {
            while (true)
            {
    			yield return new WaitForSeconds(0.05f);
    			Spawn();
            }
        }
    
        [ContextMenu("Spawn")]
        public void Spawn()
        {
            Vector3 spawnPoint = FindPoint(player.position, distance, Random.Range(0, 360));
            Instantiate(prefab, spawnPoint, Quaternion.identity, transform);
        }
    
        [ContextMenu("Clear")]
        public void Clear()
        {
            foreach (var item in transform.GetComponentsInChildren<Transform>())
            {
                if (item != transform)
                    DestroyImmediate(item.gameObject);
            }
        }
    
        Vector3 FindPoint(Vector3 center, float radius, int angle)
        {
            return center + Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.right * radius);
        }
    }
