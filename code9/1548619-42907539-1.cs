    using UnityEngine;
    using System.Collections;
    
    public class theScript : MonoBehaviour {
        public GameObject prefab1;
        public int MaxInstantiation = 5;
    
        void Start ()
        {
            StartCoroutine( InstantiatePrefab(1) ) ;
        }
    
        private IEnumerator InstantiatePrefab( float delay = 1f )
        {
            WaitForSeconds waitDelay = new WaitForSeconds( delay ) ;
            for( int instantiateCount = 0 ; instantiateCount < MaxInstantiation ; ++instantiateCount )
            {
                yield return waitDelay ;
                Instantiate (prefab1, transform.position, transform.rotation ) ;
            }
            yield return null ;
        }
    }
