    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class EventTest : MonoBehaviour
    {
    	public InputField[] inputFields;
    
    	void Start ()
    	{
    		foreach(InputField field in inputFields)
    		{
    			var se = new InputField.SubmitEvent();
    			se.AddListener(delegate {
    				SubmitText(field.name, field.text);
    			});
    			field.onEndEdit = se;
    		}
    	}
    
    	public void SubmitText(string prefValue, string val)
    	{
    		Debug.Log("Saved " + val + " to " + prefValue);
    	}
    }
