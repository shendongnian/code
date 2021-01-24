    public class SceneManagerScript : MonoBehaviour {
        public GameObject objPrefab;
        public GameObject ground;
        private int count = 0;
        public void spawnObject() {
            Instantiate(objPrefab, new Vector3(count, 0, 0), Quaternion.identity, ground.transform);
        count += 2; 
        }
    }
