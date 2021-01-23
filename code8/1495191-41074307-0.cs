    public class Playervitals : MonoBehaviour
    {
        //Objetos
        [Header("Objetos")]
        public List<GameObject> spawnPositions;
        public List<GameObject> spawnObjects;
        private GameObject[] despawnObjects;
    
    
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                SpawnObjectsZ();
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                GameObject[] despawnObjects = GameObject.FindGameObjectsWithTag("ItemZona");
                for (int i = 0; i < despawnObjects.Length; i++)
                {
                    PoolManager.Pools["Objetos"].Despawn(despawnObjects[i].transform);
                    Debug.Log("Despawnea Objetos");
                }
            }
        }
    
        void SpawnObjectsZ()
        {
            foreach (GameObject spawnPosition in spawnPositions)
            {
                int selection = Random.Range(0, spawnObjects.Count);
                PoolManager.Pools["Objetos"].Spawn(spawnObjects[selection], spawnPosition.transform.position, spawnPosition.transform.rotation);
                spawnObjects.Remove(spawnObjects[selection]); //REMOVE FROM LIST
            }
        }
    }
