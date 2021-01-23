    using UnityEngine;
    
    public class NewBehaviourScript : MonoBehaviour 
    {
    	void Start () {
    		if (SystemInfo.unsupportedIdentifier != SystemInfo.deviceUniqueIdentifier)
    		{
    			// use SystemInfo.deviceUniqueIdentifier
    		}	
    	}
    }
