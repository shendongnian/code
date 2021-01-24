    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Instantiter : MonoBehaviour {
        public GameObject[] gameobject;
        public float  SpawnDelay= 3f;
        private GameObject objectkeeper;
        // Static variable shared across all instances of this script
        public static float nextSpawn = 0f;
        // Use this for initialization
        void Start () {
    
        }
    
        // Update is called once per frame
        void Update () {
            // check if SpawnDelay duration has passed
            if (Time.time >= nextSpawn) {
    	        // Now spawn after ramdom time
    	        float Spawntime = SpawnDelay * Time.deltaTime; // 1 *1/60
    	        if (Random.value < Spawntime) {
    	            Spawn ();
    	        }
    	    }
        }
    
        void Spawn(){
            int number = Random.Range (0, 2);// creating random number between 0 and 1
            objectkeeper = Instantiate (gameobject [number], this.transform.position, Quaternion.identity) as GameObject;
            objectkeeper.transform.parent = this.transform;
            // Set the nextSpawn time to after SpawnDelay Duration
            nextSpawn = Time.time + SpawnDelay;
        }
    
        void OnDrawGizmos(){
            Gizmos.DrawWireSphere (this.transform.position, 0.5f);
        }
    }
