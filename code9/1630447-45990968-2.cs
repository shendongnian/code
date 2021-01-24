    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    
    
    public class Push : MonoBehaviour {
    
    	public Transform target;
    	public Transform end;
    
    	bool movingForward = true;
    
    	float speed = 9f;
    
    	bool moving = false;
    	
    	// Update is called once per frame
    	void Update () {
    
    		if(movingForward)
    		 {
    			//transform.position = new Vector3(transform.position.x + 0.001f, transform.position.y, transform.position.z);
    			float step = speed * Time.deltaTime;
    			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    
    			if(transform.position.Equals(target.position))
    				movingForward = false;
    		 }else{
    			float step = speed * Time.deltaTime;
    			transform.position = Vector3.MoveTowards(transform.position, end.position, step);
    
    			if(transform.position.Equals(end.position))
    				movingForward = true;
    		 }
    
    	}
    
    	void OnTriggerEnter(Collider other)
    	{
    	    print("Something Inside");
    		if(other.tag == "Player")
    		{
    			print("It is the player");
    			other.gameObject.GetComponent<Rigidbody>().isKinematic=true;
    			other.gameObject.transform.parent = this.transform;
    		}
    	}
    
    	void OnTriggerExit(Collider other)
    	{
    		if(other.tag == "Player")
    		{
    			other.gameObject.GetComponent<Rigidbody>().isKinematic=false;
    			other.gameObject.transform.parent = null;
    		}
    	}
    
    }
