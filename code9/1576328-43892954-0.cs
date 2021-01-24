    using System;
    
    public class Program
    {
    	public class TypeA
    	{
    		public int Id;
    	}
    
    	public class TypeB : TypeA
    	{
    		public int name;
    	}
    
    	public static void Main()
    	{
    		var t = new TypeB{Id = 1, name = 15};
    		if (t is TypeA)
    		{
    			TypeA a = (TypeA)t;// no error
    			Console.WriteLine(a.Id); // no error
    		}
    	}
    }
