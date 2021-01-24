    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class UITestSO : MonoBehaviour 
    {
    
    	public Text textObject;
    	void Start () 
    	{
    
    		//Position relative to parent transform
    		textObject.rectTransform.localPosition = new Vector3 (-210, -200, 0);
    
    		//Position in world space
    		textObject.rectTransform.position = new Vector3 (-210, -200, 0);
    	}
    }
