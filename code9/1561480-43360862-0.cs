    void Main()
    {
    	MemberInfo a = typeof(a).GetMember("b")[0];
    	MemberInfo b = typeof(a).GetMember("b")[0];
    
    	Console.WriteLine(Object.ReferenceEquals(a, b));
    }
    
    // Define other methods and classes here
    class a
    {
    	public int b;
    }
