	using System;
	using System.Linq;
	using Demo.Extensions;
	namespace Demo
	{
	    class MainClass
	    {
	        public static void Main(string[] args)
	        {
	            var items = Enumerable.Range(1, 100).Page(2, 10);
	            foreach (var item in items)
	            {
	                Console.WriteLine(item);
	            }
	            Console.ReadKey();
	        }
	    }
	}
