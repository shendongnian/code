    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI; 
    
    public class LayoutGroupExample : MonoBehaviour {
    
    	public GameObject layoutObject; 
    	public GameObject inputFieldPrefab; 	
    
    	void AddInputFields(){
    		var inputFieldList = new List<string>(){"First Name", "Last Name", "Email"}; 
    
    		foreach(var fieldName in inputFieldList){
    			GameObject go = GameObject.Instantiate(inputFieldPrefab); 
    			go.name = fieldName; 
    			go.transform.SetParent(layoutObject.transform); 
    			var inputField = go.AddComponent<InputField>(); 
    		}
    	}
    }
