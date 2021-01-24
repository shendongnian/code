    public class ImageSpawnerScreen : MonoBehaviour {
        public float waitTime = 2;
        public float cubeSpawnTotal = 10;
        public List<GameObject> cubePrefabList;
    
        public GameObject panel;
        void Start()
        {
            StartCoroutine(SpawnCube());
        }
    
    
        IEnumerator SpawnCube()
        {
            for (int i = 0; i < cubeSpawnTotal; i++)
            {
                GameObject prefabToSpawn = cubePrefabList[Random.Range(0, cubePrefabList.Count - 1)];
                //Vector3 spawnPosition = Camera.main.ScreenToViewportPoint(new Vector3(Random.Range(0,Screen.width),0,Random.Range(0,Screen.height)));  //Random.Range(xPosMinLimit, xPosMaxLimit);
    
                float xPos = Random.Range(0, Screen.width);
                float yPos = Random.Range(0, Screen.height);
                Vector3 spawnPosition = new Vector3(xPos, yPos, 0f);
                GameObject spwanObj = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity) as GameObject;
                spwanObj.transform.parent = panel.transform;
                spwanObj.transform.position = spawnPosition;
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
