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
    			A myClass1WithStaticConstructor = new A();
    			A myClass2WithStaticConstructor = new A();
    		} 
    	} 
    	public class A 
    	{ 
    		public A()
    		{
    			Console.WriteLine("default constructor is called."); 
    		}
    		static A() 
    		{ 
    			Console.WriteLine("static constructor is called."); 
    		} 
    	} 
    }
