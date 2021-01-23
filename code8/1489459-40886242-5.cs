    using UnityEngine;
    using System.Collections;
    
    public class sphereScript : MonoBehaviour {
    	// Am I alive?
    	public bool isAlive;
    
    	// Use this for initialization
    	void Start () {
    		// Add a function we want to be called when the EventManager invokes PostCollision
    		EventManager.PostCollision += PostCollision;
    		isAlive = true;
    	}
    	
    	// Update is called once per frame
    	void Update () {
    	
    	}
    
    	//Invoked from EventManager.PostCollision delegate
    	void PostCollision(string message){
    		if(isAlive)
    			Debug.Log (this.name + " message received: " + message);
    	}
    
    	// Called when it is time to destroy this gameobject
    	public void Kill(){
    		isAlive = false;
    		Destroy (this.gameObject);
    	}
    
    	//On collision with another object
    	void OnCollisionEnter2D(Collision2D collision){
    		if (collision.gameObject.GetComponent<sphereScript>()) {
    			EventManager.Collision (this.gameObject, collision.gameObject, collision.contacts [0].point);
    		}
    	}
    
    	// Called after this object has been destroyed
    	void OnDestroy(){
    		// cleanup events for performance.
    		EventManager.PostCollision -= PostCollision;
    	}
    }
