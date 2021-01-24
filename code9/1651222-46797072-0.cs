    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ListInInspectorTest : MonoBehaviour {
    
        public List<Vector3> superawesomeListOfVector3s;
    	
    	void Update () {
    		
            if(superawesomeListOfVector3s.Count < 10) {
                superawesomeListOfVector3s.Add(Random.insideUnitSphere);
            }
    
    	}
    }
