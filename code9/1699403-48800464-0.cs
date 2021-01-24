    using System.Collections;
    using UnityEngine;
    
        public class Activar : MonoBehaviour {
        	public GameObject modify;
        
        	void Update () {
        		if (Input.GetMouseButton (0))
        			modify.SetActive (false);
        	    else 
        			modify.SetActive (true);
        	}
        }
