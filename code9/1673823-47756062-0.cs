    public class Spawner : MonoBehaviour 
    {
        public Transform player;
        public Transform prefab;
    
        public float distance = 20f;
    
        [Range(1, 200)]
        public float objectCount = 10f;
    
        [ContextMenu("Spawn")]
        public void Spawn()
        {
            for (int i = 0; i < objectCount; i++)
            {
                Vector3 spawnPoint = FindPoint(player.position, distance, Random.Range(0, 360));
                Instantiate(prefab, spawnPoint, Quaternion.identity, transform);
            }
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
