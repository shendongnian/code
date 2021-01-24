    using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			IList<object> foo = new List<object> {
				new Bird(),
				new Cat(),
				new Cat(),
				new Dog(),
				new Bird(),
				new Dog(),
				new Cat(),
				new Dog(),
				new Cat(),
				new Dog()
			};
			var dogCount = foo.Count(x => x is Dog);
			Console.WriteLine($"{dogCount} dogs.");
		}
	}
	public class Dog
	{
		public string Sound { get { return "Woof"; } }
	}
	public class Cat
	{
		public string Sound { get { return "Meow"; } }
	}
	public class Bird
	{
		public string Sound { get { return "Tweet"; } }
	}
