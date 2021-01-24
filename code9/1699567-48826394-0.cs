    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class PlayerSkiftStørelse : MonoBehaviour {
    
    	public Vector3 small;
    	public Vector3 normal;
    	public Vector3 high;
    	public Vector3 offset;
    	
    	// Update is called once per frame
    	void Update () 
    	{
    		if (Input.GetKeyDown (KeyCode.DownArrow))  //getkeydown??
    		{
    			transform.localScale = small;
    		} 
    
    		if (Input.GetKeyDown (KeyCode.UpArrow))  //getkeydown??
    		{
    			transform.localScale = normal;
    		} 
    
    	}
    }
