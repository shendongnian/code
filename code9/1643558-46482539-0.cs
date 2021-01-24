    public static List<GameObject> spawnedObjects = new List<GameObject>();
    
    void Start()
    {
        spawnedObjects.Add(gameObject);
    }
    
    void OnDestroy()
    {
        spawnedObjects.Remove(gameObject);
    }
