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
              Destroy(gameObject);
           }
    		curLevel = currentLevel;
    		totLevel = totalEnemy;
    	}
    }
