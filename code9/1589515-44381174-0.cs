    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class MyObjectSpawner : MonoBehaviour {
        public Transform Prefab;
        
        public void Spawn(string data) {
            var instance = Instantiate(Prefab);
            
            // do what you like with your instantiated object and the data from the javascript here    
        }
    }
