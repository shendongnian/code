    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class CamTest : MonoBehaviour {
    	public float animSpeed = 1.0f;
    	public Camera Cam;
    	private Quaternion startRotation;
    	private bool doRotate = false;
    
    	// Use this for initialization
    	void Start () {
    		//Cam = GetComponent<Camera> ();
    		startRotation = transform.rotation;
    	}
    	
    	void Update () {
    
    		if (Input.GetKey(KeyCode.W)) 
    		{
    			Cam.transform.Rotate (0, 0, 2);
    		}
    		if (Input.GetKey(KeyCode.S) )
    		{
    			Cam.transform.Rotate (0, 0, -2);
    		}
    
    		if (Input.GetKey(KeyCode.D)) 
    		{
    			Cam.transform.Rotate (0, 2, 0);
    		}
    		if (Input.GetKey(KeyCode.A)) 
    		{
    			Cam.transform.Rotate (0, -2, 0);
    		}
    
    		if (Input.GetButtonDown("Fire1")) {
    			Debug.Log ("Fire1");
    			doRotate = true;
    		}
    		if(doRotate) DoRotation ();
    	}
    
    	void DoRotation(){
    		if (Quaternion.Angle(Cam.transform.rotation, startRotation) > 1f) {
    			Cam.transform.rotation = Quaternion.Lerp(Cam.transform.rotation, startRotation,animSpeed*Time.deltaTime);
    		} else {
    			Cam.transform.rotation = startRotation;
    			doRotate = false;
    		}
    	}
    }
