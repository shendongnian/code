    using UnityEngine;
    [RequireComponent (typeof (Ray))]
    public class colorChange : MonoBehaviour {
	    private Ray rayReference = null;
	
        protected void Awake() {
	        rayReference = GetComponent<Ray>();
	    }
	    protected int getRayHitpoints()  {
            return rayReference.Hitpoints;
	    }
        // ... other methods that may use getRayHitpoints ...
    }
