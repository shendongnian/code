	using System;
	using System.Linq;
	using System.Collections.Generic;
	
	public class Vector
	{
		public int X {get; set;}
		public int Y {get; set;}
		public int Z {get; set;}	
	}
						
	public class Program
	{
		public static void Main()
		{
			Dictionary<Vector, int> map = new Dictionary<Vector, int>();
			
			var vector = new Vector() { X = 4, Y = 5, Z = 6 };
			map.Add(vector, 3);
			
			int result = 0;
			if (map.Keys.Contains(vector))
			{
				result = map[vector];
			}
			Console.WriteLine(result);
		}
	}
