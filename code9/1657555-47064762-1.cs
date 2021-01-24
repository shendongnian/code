    using System.Collections.Generic;
    using UnityEngine;
    
    public class JsonExample : MonoBehaviour
    {
        [System.Serializable] // May be required, but tested working without.
    	public class Game
    	{
    		public int idCurrentLevel;
    		public int idLastUnlockedLevel;
    		public List<Level> levels;
    
    		public Game()
    		{
    			idCurrentLevel = 17;
    			idLastUnlockedLevel = 16;
    			levels = new List<Level>()
    			{
    				new Level(){id = 0, name = "First World" },
    				new Level(){id = 1, name = "Second World" },
    			};
    		}
    
    		public override string ToString()
    		{
    			string str = "ID: " + idCurrentLevel + ", Levels: " + levels.Count;
    			foreach (var level in levels)
    				str += " Lvl: " + level.ToString();
    
    			return str;
    		}
    	}
        
        [System.Serializable] // May be required, but tested working without.
    	public class Level
    	{
    		public int id;
    		public string name;
    
    		public override string ToString()
    		{
    			return "Id: " + id + " Name: " + name;
    		}
    	}
    
    	private void Start()
    	{
    		Game game = new Game();
    
    		// Serialize
    		string json = JsonUtility.ToJson(game);
    		Debug.Log(json);
    
    		// Deserialize
    		Game loadedGame = JsonUtility.FromJson<Game>(json);
    		Debug.Log("Loaded Game: " + loadedGame.ToString());
    	}
    }
