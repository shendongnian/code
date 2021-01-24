    [System.Serializable]
     public class Levels
     {
         public LevelInfo[] levelInfo;
     }
    
     [System.Serializable]
     public class LevelInfo
     {
         public bool isCompleted;
         public string levelName;
         public int levelScore;
    
         //Other Level Information here
     }
