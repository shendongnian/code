    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Instantiter : MonoBehaviour {
        public GameObject[] prefabs;
        public float  MinimumSpawnDelay = 3f;
        public float  MaximumSpawnDelay = 6f;
        
    	private GameObject spawnedObject;
    	private float nextSpawnTime;
        
    	// Use this for initialization
        void Start () {
    		SetNextSpawnTime();
        }
    
        // Update is called once per frame
        void Update () {
            if (Time.time <= nextSpawnTime) {
                Spawn ();
            }
        }
    
        void Spawn(){
    	    // allows you to add more objects to the prefabs array without changing code.
    		var prefabToSpawn = prefabs[Ranom.Range(0, prefabs.Length)];
    		
            spawnedObject = Instantiate (prefabToSpawn, this.transform.position, Quaternion.identity);
            spawnedObject.transform.parent = this.transform;
    		
    		SetNextSpawnTime();
        }
    
        void OnDrawGizmos()	{
            Gizmos.DrawWireSphere (this.transform.position, 0.5f);
        }
    	
    	void SetNextSpawnTime(){
    		nextSpawnTime = Time.time + Random.Range(MinimumSpawnDelay, MaximumSpawnDelay);
    	}
    }
