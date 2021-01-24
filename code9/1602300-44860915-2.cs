    using System; 
    using System.Collections.Generic;
    using System.Linq; 
    using System.Text;
    namespace ConsoleApplication6 
    {
    	public class Program 
    	{ 
    		public static void Main(string[] args) 
    		{ 
    			Console.WriteLine(A.abc);
    		} 
    	} 
    	public static class A 
    	{ 
    		public static int abc;
    
    		static A() 
    		{ 
    			abc=10;
    			Console.WriteLine("static constructor is called."); 
    		} 
    	} 
    }
