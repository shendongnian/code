    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class SpawnRigidbody : MonoBehaviour 
    {
    
    	public Rigidbody2D ball;
    	Vector2 sp = new Vector2(0f, 2.1f);
    
    	void Update() 
    	{
    		if (Input.GetKeyDown("w")) {
    			SpawnBall();
    		}
    	}
    
    	void SpawnBall()
    	{
    		Debug.Log ("spawn");
    		GameObject go = Instantiate(ball, sp, transform.rotation).gameObject;
    		go.AddComponent<DestroyAfterPosition> ();
    	}
    }
