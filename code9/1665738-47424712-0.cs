    using System;
	using System.Linq;
	public class Program
	{
	
		static readonly Random _random = new System.Random(Environment.TickCount);
		const string dictionary = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklpmnopqrstuvwxyz0123456789!@#$%^&*()_+-=";
	
		static string GetPassword(int length)
		{
			return new String
				(
					dictionary
					   .OrderBy( a => _random.NextDouble() )
					   .Take(length)
					   .ToArray()
				);
		}
			
	
		public static void Main()
		{
			var s = GetPassword(30);
			Console.WriteLine(s);
		}
	}
