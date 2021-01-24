    [System.Serializable] // tells unity that this class is serializable and therefore it can show up in the inspector
    public class ChestValue 
    {
         // Pretty sure you need a default constructor as the class is serializable
        public ChestValue(){}
        public ChestValue(GameObject prefab, int count) // fill the data
        {
            ItemToSpawn = prefab;
            SpawnCount = count;
        }
    
        // switched properties to variables so the editor can 'see' them
        public GameObject ItemToSpawn;
        public int SpawnCount;
    }
