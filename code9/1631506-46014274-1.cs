    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MoveLift : MonoBehaviour {
    
        public Transform end;
    
        float speed = 4f;
    
    	bool liftActivated = false;
    
    	// Use this for initialization
    	void Start () {
    		
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		if(liftActivated)
    		 {
    			float step = speed * Time.deltaTime;
                //To move up the lift
    			transform.position = Vector3.MoveTowards(transform.position, end.position, step);
                //To spin the lift
    			transform.RotateAround(Vector3.up, 2 * Time.deltaTime);
                
                //To stop spining the lift when it reaches the end of the path
    			if(transform.position.Equals(end.position))
    				liftActivated = false;
    		 }
    	}
    
    	void OnTriggerEnter(Collider other){
    		liftActivated = true;
    		other.gameObject.transform.parent = this.transform;
            other.gameObject.GetComponent<Rigidbody>().isKinematic=true;
    	}
    }
