	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	namespace ConsoleApplication7
	{
		public class MyAttribute : Attribute
		{
			public MyAttribute(int val)
			{
				Value = val;
			}
			public int Value { get; set; }
		}
		class Test
		{
			[MyAttribute(1)]
			public void Method1()
			{
				Console.WriteLine("1!");
			}
			[MyAttribute(2)]
			public void Method2()
			{
				Console.WriteLine("2!");
			}
			[MyAttribute(3)]
			public void Method3()
			{
				Console.WriteLine("3!");
			}
			[MyAttribute(1)]
			public void Method4()
			{
				Console.WriteLine("4!");
			}
		}
		class Program
		{
			static void Main(string[] args)
			{
				var test = new Test();
				MethodInfo[] methods = Assembly.GetAssembly(test.GetType()).GetTypes()
					.SelectMany(t => t.GetMethods())
					.Where(m => 
						{
							var attr = m.GetCustomAttributes(typeof(MyAttribute), false);
							return attr.Length > 0 && ((MyAttribute)attr[0]).Value == 1;
						})
					.ToArray();
				foreach (var method in methods)
				{
					method.Invoke(test, null);
				}
			}
		}
	}
