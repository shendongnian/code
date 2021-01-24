    using UnityEngine.UI;
    
    public class SafeButton : Button
    {
        override protected void Awake()
    	{
    		for (int i = 0; i < onClick.GetPersistentEventCount(); i++)
    		{
    			var methodName = onClick.GetPersistentMethodName(i);
    			// if method name contains "missing"
    				// -> Log Error
    		}
    	}
    }
