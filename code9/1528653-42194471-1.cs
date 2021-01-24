    public class ItemController : MonoBehaviour {
    
        public int spawnLocation;
        public event System.Action<int> OnDestroy;
    
    
        void Start()
        {
            spawnLocation = ItemManager.spawnPointIndex;
        }
    
        void DestroyObject()
        {
            if (whenConditionIsTrue == true){
                Destroy(this.gameObject);
                OnDestroy(this.spawnLocation);
            }
            ObjectMouseDown = false;
        }
    }
