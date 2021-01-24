    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Instantiter : MonoBehaviour {
        public GameObject[] prefabs;
        public float  MinimumSpawnDelay = 3f;
        public float  MaximumSpawnDelay = 6f;
        
    	private GameObject spawnedObject;
    	private static float nextSpawnTime;
        
    	// Use this for initialization
        void Start () {
            // Artificial delay so we do not spawn an object directly at startup
    		SetNextSpawnTime();
        }
    
        // Update is called once per frame
        void Update () {
            if (Time.time >= nextSpawnTime) {
                Spawn ();
            }
        }
    
        void Spawn(){
    	    // allows you to add more objects to the prefabs array without changing code.
    		var prefabToSpawn = prefabs[Ranom.Range(0, prefabs.Length)];
    		
            spawnedObject = Instantiate (prefabToSpawn, transform.position, Quaternion.identity);
            spawnedObject.transform.parent = transform;
    		
    		SetNextSpawnTime();
        }
    
        void OnDrawGizmos()	{
            Gizmos.DrawWireSphere (transform.position, 0.5f);
        }
    	
    	void SetNextSpawnTime(){
            // a simple variable to hold when we should spawn another object, efficient.
    		nextSpawnTime = Time.time + Random.Range(MinimumSpawnDelay, MaximumSpawnDelay);
    	}
    }
