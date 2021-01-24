    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var obj1 = new SomeClass1();
    		var obj2 = new SomeClass2();
    		
    		obj1._objects.Add(3);
    		obj2._objects.Add(7);
    
    		Console.WriteLine(obj1.Method());
    		Console.WriteLine(obj2.Method());
    	}
    }
    
    public class SomeClass1 : CommonClass
    {
    }
    public class SomeClass2 : CommonClass
    {
    }
    
    public class CommonClass
    {
    	public List<int> _objects;
        public int Method()
    	{
    	return this._objects[0];
    	}
    	public CommonClass()
    	{
    		_objects = new List<int>();
    	}
    }
