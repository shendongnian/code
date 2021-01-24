    [System.Serializable]
    public class PlayerData
    {
    
        public int maxHealth;
        public int currentHealth;
        public int currentLevel;
        public int currentExp;
        public int[] toLevelUp;
    }
    
    string saveLocation = "/data.dat";
    
    //Make the PlayerData data part of your game
    PlayerData playerData;
    
    void Start()
    {
    
        playerData = new PlayerData();
        playerData.maxHealth = 100;
        playerData.currentLevel = 1;
        playerData.currentHealth = 50;
    }
    
    public void Save(PlayerData pData)
    {
        UnityEngine.Debug.Log("Saving");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + saveLocation);
        bf.Serialize(file, pData);
        file.Close();
    }
