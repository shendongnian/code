    using UnityEngine;
    [RequireComponent (typeof (Rays))]
    public class colorChange : MonoBehaviour {
	    private Rays raysReference = null;
	
        protected void Awake() {
	        raysReference = GetComponent<Rays>();
	    }
	    protected int getRaysHitpoints()  {
            return raysReference.Hitpoints;
	    }
        // ... other methods that may use getRaysHitpoints ...
    }
