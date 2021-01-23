    void Main()
    {
    	var obj = new TestObject();
    	foreach (var prop in obj.GetType().GetProperties())
    	{
    		Console.WriteLine("{0} = '{1}'", prop.Name, prop.GetValue(obj));
    	}
    }
    
    class TestObject
    {
    	public TestObject()
    	{
    		FirstName = "John";
    		LastName = "Hancock";
    	}
    
    	public string FirstName { get; }
    	public string LastName { get; }
    }
