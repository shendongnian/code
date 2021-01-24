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
				new Poodle(),
				new Cat(),
				new Dog(),
				new Husky(),
				new Dachshund(),
				new Poodle(),
				new Cat(),
				new Dog()
			};
			var dogCount = foo.Count(x => x is Dog);
			Console.WriteLine($"{dogCount} dogs.");
		}
	}
	public class Dog
	{
		public virtual string Sound { get { return "Woof"; } }
	}
	public class Dachshund : Dog
	{
		public override string Sound { get { return "Ruff"; } }
	}
	public class Husky : Dog
	{
		public override string Sound { get { return "Yarp"; } }
	}
	public class Poodle : Dog
	{
		public override string Sound { get { return "Yip"; } }
	}
	public class Cat
	{
		public string Sound { get { return "Meow"; } }
	}
	public class Bird
	{
		public string Sound { get { return "Tweet"; } }
	}
