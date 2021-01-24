    using UnityEngine;
    using System.Collections;
    
    public class theScript : MonoBehaviour {
        public GameObject prefab1;
        public int FiveTimeCheck;
    
        // Use this for initialization
        void Start () {
            FiveTimeCheck = 0;
            InvokeRepeating ("Instant_", 1f, 1f);
        }
    
        // Update is called once per frame
        void Update () {
    
        }
    
        void Instant_(){
            if(FiveTimeCheck <= 5)
            {
                FiveTimeCheck += 1;
                Instantiate (prefab1, transform.position, transform.rotation );
            }
        }
    }
