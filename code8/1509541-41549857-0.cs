    public static class DestroyedObject : MonoBehaviour
    {
        public static DestroyedObject Instance;
        private static List<GameObject> objs = new List<GameObject>();
        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                DestroyImmediate(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        public static void Add(GameObject obj) 
        {
            if(!objs.Contains(obj))
                objs.Add(obj); 
        }
        public static List<GameObject> GetDestroyedObjects()
        {
            return objs;
        }
    }
