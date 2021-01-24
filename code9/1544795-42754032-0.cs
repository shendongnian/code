    public static class TestStatic
    {
    	public static int SomeValue = GetValue();
    
    	static TestStatic()
    	{
    		Console.WriteLine("Constructor");
    	}
    	
    }
