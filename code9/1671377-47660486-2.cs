    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var ar = new Buy[]{
    			new Buy(){Price = 1, Name = "shirt"}, 
    			new Buy(){Price = 2, Name = "hat"}, 
    			new Buy(){Price = 3, Name = "dog"}
    		};
    		
    		Console.WriteLine(ar.OrderByDescending(b => b.Price).First().Name);
    		Console.WriteLine(ar.OrderBy(b => b.Price).First().Name);
    	}
    	
    	internal class Buy{
    		public int Price;
    		public string Name;
    	}
    }
