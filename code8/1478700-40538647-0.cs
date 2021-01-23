    public class MyTable
    {
    	public delegate string OnInsertHandler();
    	public event OnInsertHandler OnInsert;
    
    
    	public string Show()
    	{
    		string res = "-BEGIN-";
    		if (OnInsert != null) {
    			res += OnInsert ();
    		} else {
    			res += "#default insert#";
    		}
    
    		res += "-END-";
    
    		return res;
    	}
    }
    
    
    public class DelegateTester
    {
    
    	public void OnTest()
    	{
    		MyTable mt = new MyTable();
    
    		Debug.Log("Default output: " + mt.Show());	// Shows "-BEGIN-#default insert#-END-"
    
    		// Changing functionality via delegate
    		mt.OnInsert += MyCustomInsert;
    
    		Debug.Log("Customized output: " + mt.Show());	// Shows "-BEGIN-#custom insert#-END-"
    
    		// Remove delegate
    		mt.OnInsert -= MyCustomInsert;
    
    		Debug.Log("Rollbacked output: " + mt.Show());	// Shows "-BEGIN-#default insert#-END-"
    	}
    
    	public string MyCustomInsert()
    	{
    		return "#custom insert#";
    	}
    }
