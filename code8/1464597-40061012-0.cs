    class MyCustomAttribute : Attribute {
    	public int[] Values { get; set; }
    }
    
    [MyCustomAttribute(Values = new int[] { 3, 4, 5 })]
    class MyClass { }
