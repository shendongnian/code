    public class vmA : modelA
    {
    	public vmA()
    	{
    		SomeValue = 254.43F; //This value is shown when the control is loaded
    	}
    
    	public void SetSomeValue(int _someValue)
    	{
    		SomeValue = _someValue; // If this is executed, the view still shows 254.43, even though _someValue contains a different value
    	}
    }
