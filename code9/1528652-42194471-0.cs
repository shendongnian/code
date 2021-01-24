    public class ItemManager : MonoBehaviour {
    
        public GameObject Item;
        private float spawnTime = 3f;
        public Transform[] spawnPoints;
        static public int spawnPointIndex;
    
        void Start () {
            for(int i = 0; i < spawnPoints.Length; i++)
            {
                spawnPointIndex = i;
                GameObject itemObject = Instantiate(Item, spawnPoints[spawnPointIndex].position,spawnPoints[spawnPointIndex].rotation);
                itemObject.GetComponent<ItemController>().OnDestroy += SpawnNewItem;
            }
        }   
    
        public void SpawnNewItem(int i) {
            //spawn new item at index i
        }
    }
