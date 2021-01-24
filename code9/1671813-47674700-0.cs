    public class ImageSpawnerScreen : MonoBehaviour
    {
        public float waitTime = 2;
        public float cubeSpawnTotal = 10;
        public List<GameObject> imagesList;
        public RectTransform panel;
        void Start()
        {
            StartCoroutine(SpawnImage());
        }
        IEnumerator SpawnImage()
        {
            for (int i = 0; i < cubeSpawnTotal; i++)
            {
                GameObject imageToSpawn = imagesList[Random.Range(0, imagesList.Count)]; // Remove -1 after count since is exclusive for int (https://docs.unity3d.com/ScriptReference/Random.Range.html)
                Vector3 spawnPosition = GetBottomLeftCorner(panel) - new Vector3(Random.Range(0, panel.rect.x), Random.Range(0, panel.rect.y), 0);
               
                print("Spawn image at position: " + spawnPosition);
                GameObject spwanObj = Instantiate(imageToSpawn, spawnPosition, Quaternion.identity, panel);
                yield return new WaitForSeconds(waitTime);
            }
        }
        Vector3 GetBottomLeftCorner(RectTransform rt)
        {
            Vector3[] v = new Vector3[4];
            rt.GetWorldCorners(v);
            return v[0];
        }
    }
