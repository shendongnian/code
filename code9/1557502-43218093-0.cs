    using System;
	namespace Example
	{
	    public class Child
	    {
	        public string Property1 { get; set; }
	    }
	    public class Parent
	    {
	        public string Property1 { get; set; }
	        public string Property2 { get; set; }
	        public string Property3 { get; set; }
	        public Child Property4 { get; set; }
	    }
	    public class Program
	    {
	        static void Main(string[] args)
	        {
	            var foo = new Parent
	            {
	                Property1 = "Hi",
	                Property2 = "there",
	                Property3 = "Svenja",
	                Property4 = new Child
	                {
	                    Property1 = "Löffel"
	                }
	            };
	            Console.ReadLine();
	        }
	    }
	}
