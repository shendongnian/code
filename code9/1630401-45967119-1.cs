    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class moveObject : MonoBehaviour {
    
    	public GameObject handEmptyGameObject;
    	GameObject item = null;
    
    	bool objectOnRange = false;
    
    	// Use this for initialization
    	void Start () {
    	    //This is useful if you have just one item to collect in your scene
    	    //if you have more than one, better remove it
    		item = GameObject.FindGameObjectsWithTag("item");
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		if(Input.GetKeyDown(KeyCode.G) && objectOnRange)
    		{
    			print("Grabbing an object");
    			item.transform.position = hand.transform.position;
    
    			item.transform.SetParent(hand.transform,true);
    		}
    	}
    
    	//You need to tag the GameObjec tto grab as "item" and set a 
    	//collider and rigid bodies in the GameObjects
    	//This is to estimate if the player is close enough to the Object
    
    	void OnTriggerEnter(Collider other)
    	{
    		if(other.tag == "item")
    		{
    			objectOnRange = true;
    			item = other.gameObject;
    		}
    	}
    
    	void OnTriggerExit(Collider other)
    	{
    		if(other.tag == "item")
    		{
    			objectOnRange = false;
    			item = other.gameObject;
    		}
    	}
    
    }
