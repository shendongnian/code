    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public class SomeClass
    	{
    		public string Parent { get; set; }
    		public string Child { get; set; }
    	}
    	
    	
    	public static void Main()
    	{
    		var datas = new List<SomeClass>
    		{
    			new SomeClass{ Parent = "Bob", Child = "Brett" },
    			new SomeClass{ Parent = "Bob", Child = "Cindy" },
    			new SomeClass{ Parent = "Bob", Child = "John" },
    			new SomeClass{ Parent = "Alice", Child = "Pierre" },
    			new SomeClass{ Parent = "Alice", Child = "John" }
    		};
    		
    		var groups = datas.GroupBy(n => n.Parent)
    			.Select(n => new
    			{
    				Parent = n.Key,
    				Childs = string.Join(",", n.Select(i => i.Child))
    			})
    			.ToList();
    		
    		var result = string.Join("\n", groups);
    		
    		Console.WriteLine(result);
    	}
    }
