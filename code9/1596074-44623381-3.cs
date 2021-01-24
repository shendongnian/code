    using System.Collections.Generic;
    using System.Collections;
    using UnityEngine;
    
    public class GameManager : MonoBehaviour
    {
    	private static GameManager instance;
    	public static GameManager get() { return instance; }
    
    	public int currentLevel;
    	public int curLevel { get; set; }
    	public int totalEnemy;
    	public int totLevel { get; set; }
    
    	void Awake()
    	{
           if (instance == null) 
           {
              instance = this;
           }
           else 
           {
              Debug.LogError(string.Format("GameManager.Awake(): More than one instances of this type {0} is being initialised but it's meant to be Singleton and should not be initialised twice. It is currently being initialised under the GameObject {1}.", this.GetType(), this.gameObject.name));
              Destroy(gameObject);
           }
    		curLevel = currentLevel;
    		totLevel = totalEnemy;
    	}
    }
