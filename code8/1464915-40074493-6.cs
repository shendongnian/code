    public class LevelManager : MonoBehaviour
    {
        private Level currentLevelData;
        public string levelJSON;
        public int currentLevel;
        // Use this for initialization
        void Start()
        {
            currentLevelData = LevelElements(currentLevel);
            if (currentLevelData != null)
            {
                Debug.Log(currentLevelData.background);
                Debug.Log(currentLevelData.description);
                
                foreach (Enemy enemy in currentLevelData.enemies)
                {
                    Debug.Log(enemy.name);
                    Debug.Log(enemy.number);
                }
            }
            else
            {
                Debug.Log("Could not find level '" + currentLevel + "' data");
            }
        }
        Level LevelElements(int level)
        {
            string jsonText = levelJSON.ToString();
            Dictionary<string, Level> dictionary = 
                    JsonConvert.DeserializeObject<Dictionary<string, Level>>(jsonText);
            Level levelData = null;
            if (dictionary.ContainsKey(level.ToString()))
            {
                levelData = dictionary[level.ToString()];
            }
            return levelData;
        }
    }
