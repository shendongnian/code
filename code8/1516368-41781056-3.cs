    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    
    public class EventTest : MonoBehaviour
    {
    	public InputField[] inputFields;
    
    	void Start ()
    	{
    		foreach(InputField field in inputFields)
    		{
                // Get field values from player prefs if existing
                // (it should only not exist the very first time or if you delete/clear the prefs)
    			if(PlayerPrefs.HasKey(field.name))
    				field.text = PlayerPrefs.GetString(field.name);
    
    			var se = new InputField.SubmitEvent();
    			se.AddListener(delegate {
    				SubmitText(field.name, field.text);
    			});
    			field.onEndEdit = se;
    		}
    	}
    
    	public void SubmitText(string prefKey, string prefValue)
    	{
    		// store the typed text of the respective input field
    		PlayerPrefs.SetString(prefKey, prefValue);
    	}
    
    	public void ChangeScene()
    	{
    		if(SceneManager.GetActiveScene().name == "Scene1")
    		{
    			SceneManager.LoadScene("Scene2");
    		}
    		else
    		{
    			SceneManager.LoadScene("Scene1");
    		}
    	}
    }
