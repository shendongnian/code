    using UnityEngine;
    using System.Collections;
    
    public static class EventManager{
    	
    	// Create our delegate with expected params.
    	// NOTE params must match SphereScript.PostCollision declaration
    	public delegate void CollideEvent(string message);
    
    	// Create the delegate instance. This is the one we will invoke.
    	public static event CollideEvent PostCollision;
    
    	// Called whenever an object has collided with another
    	public static void Collision(GameObject obj1, GameObject obj2, Vector3 collisionPoint){
    		if (obj1.GetComponent<sphereScript>().isAlive && obj2.GetComponent<sphereScript>().isAlive) {
    
    			//Kill the 2 objects which haev collided.
    			obj1.GetComponent<sphereScript> ().Kill ();
    			obj2.GetComponent<sphereScript> ().Kill ();
    
    			//Create a cube.
    			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
    			cube.transform.position = collisionPoint;
    
    			// Invoke delegate invocation list
    			PostCollision("Something is dead");
    		}
    	}
    }
