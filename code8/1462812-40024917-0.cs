    
    	public class GUIManager : MonoBehaviour {
            public enum exampleEnum{
    		    AddPanel,
    		    ListPanel
    	    }
    		//For readability you can also add "using System.Collections.Generic;" on the top of your script
    		private System.Collections.Generic.Dictionary<exampleEnum,GameObject> exampleDictionary = new System.Collections.Generic.Dictionary<exampleEnum, GameObject>();
    
    		private GameObject SomeGameObject;
    		private GameObject SomeOtherGameObject;
    
    		void Start()
    		{
    			//You have to add all the enums and objects you want to use inside your GUIManager.
    			exampleDictionary.Add (exampleEnum.AddPanel, SomeGameObject); //Add panel will be linked to SomeGameObject
    			exampleDictionary.Add (exampleEnum.ListPanel, SomeOtherGameObject); //List Panel will be linked to SomeOtherGameObject
    
    			EnablePanel(exampleEnum.AddPanel);
    		}
    			
    		void EnablePanel(exampleEnum examplePanel)
    		{
    			if (!exampleDictionary.ContainsKey (examplePanel)) //If the given panel does not exist inside the dictionary
    				return; //Leave the method
    			
    			GameObject panelToEnable = exampleDictionary [examplePanel]; //Will return the GameObject linked to given panel
    			panelToEnable.SetActive(true); //Enable the gameobject
    		}
    	}
