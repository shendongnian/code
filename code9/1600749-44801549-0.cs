        using UnityEngine;
    
        public class CheckBaseCollider : MonoBehaviour {
    	    public GameObject baseCollider;
    
    	    private void OnTriggerEnter(Collider other) {
    	    	if (other.gameObject == baseCollider) {
    		    	Debug.Log("Entered");
    		    }
    	    }
        }
