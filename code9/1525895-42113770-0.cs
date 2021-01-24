    using UnityEngine;
    using Leap;
    using Leap.Unity;
    void OnTriggerEnter(Collider other){
       FingerModel finger = other.GetComponentInParent<FingerModel>();
		if(finger){
			this.GetComponent<DisableObject> ().enabled = true;
		}
    }
