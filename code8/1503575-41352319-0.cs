    void Main()
    {
    	var my1Attribute = typeof(ITest).GetProperty("y").GetCustomAttribute(typeof(My1Attribute)) as My1Attribute;
    	Console.WriteLine(my1Attribute.x); // Outputs: 0
    }
    
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    class My1Attribute : Attribute
    {
    	public int x { get; set; }
    }
    
    interface ITest
    {
    	[My1]
    	int y { get; set; }
    }
    
    class Child : ITest
    {
    	public Child() { }
    
    	public int y { get; set; }
    }
