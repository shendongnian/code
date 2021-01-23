    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class testscript : MonoBehaviour {
    
    	[SerializeField]
    	List<KeyCode> keys; //array also acceptable here, but i prefer to use Lists
    	//for line above, this could also be a List<string> because of the other overload of Input.GetKey but this way is best practice
    
    	[SerializeField]
    	Transform transform;
    
    	[SerializeField]
    	List<Vector3> pos;
    
    	void Update(){
    		for (int i = 0; i < keys.Count; i++) { //not foreach because we will need value of i
    			if (Input.GetKey (keys [i])) { //this will be continuous, you could also use input.GetKeyDown
    				//*****************
    				//DO SOMETHING HERE
    				//*****************
    				transform.position = pos[i];
    				Debug.Log ("Yay! A key was pressed!");
    			}
    		}
    	}
    }
