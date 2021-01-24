    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class burd : MonoBehaviour {
        public bool spawning;
        private System.Random rnd = new System.Random();
    
        private Dictionary<int, int> spawnedBurdies = new Dictionary<int, int>();
        private List<int> availableBurdies = new List<int>();
    
        // Use this for initialization
        void Start () {
            for (int index = 0; index < 10; index++)
            {
                availableBurdies.Add(index);
            }
            StartCoroutine(SpawnBurdies());
    	}
        
        private IEnumerator SpawnBurdies()
        {
            while (true)
            {
                if (spawning)
                {
                    int burdIndex = rnd.Next(availableBurdies.Count);
                    spawnBurd(availableBurdies[burdIndex]);
                    availableBurdies.RemoveAt(burdIndex);
                }
                yield return new WaitForFixedUpdate();
            }
        }
    
        private void spawnBurd(int burdIndex)
        {
            Debug.Log("Spawned burd #" + burdIndex);
            List<int> burdieKeys = new List<int>();
    
            foreach (var burdie in spawnedBurdies) { burdieKeys.Add(burdie.Key); }
    
            foreach (var burdieKey in burdieKeys)
            {
                spawnedBurdies[burdieKey]--;
                if(spawnedBurdies[burdieKey] <= 0)
                {
                    spawnedBurdies.Remove(burdieKey);
                    availableBurdies.Add(burdieKey);
                }
            }
    
            spawnedBurdies.Add(burdIndex, 6);
        }
    }
