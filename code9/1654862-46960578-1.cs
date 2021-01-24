    using System;
    
    namespace SandboxConsole
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var person = new Person() {Id = 1};
    			dynamic wrapper = new ExpandoWrapper(person);
    
    			wrapper.Id = 2;
    			wrapper.NewField = "Foo";
    
    			Console.WriteLine(wrapper.Id);
    			Console.WriteLine(person.Id);
    			Console.WriteLine(wrapper.NewField);
    		}
    	}
    	public class Person
    	{
    		public int Id { get; set; }
    		public string Name { get; set; }
    		public string Address { get; set; }
    		public string Telephone { get; set; }
    	}
    }
