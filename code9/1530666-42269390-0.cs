    using System;
    
    namespace Project.Base
    {
    	public class List<T> { }
    }
    
    namespace Project.Base.Sub { }
    
    namespace Project.Base.Sub2
    {
    	using System.Collections.Generic;
    
    	public class P
    	{
    		public static void Main()
    		{
    			var list = new List<int>();
    			Console.WriteLine(list.GetType().Namespace);
    			Console.Read();
    		}
    	}
    }
