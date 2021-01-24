	using System;
	using System.Linq;
	using System.Collections.Generic;
	
	static public class ExtensionMethods
	{
		static public IEnumerable<string> AddPossibilities(this IEnumerable<string> input, string symbol, string prefix, int minLength, int maxLength)
		{
			return input
				.SelectMany
					(
						stringSoFar => Enumerable
							.Range(minLength, maxLength-minLength+1)
							.Select
								(
									length => stringSoFar  +
										(
											length == 0
											? ""
											: prefix + Enumerable
												.Range(0, length)
												.Select(i => symbol)
												.Aggregate((c, n) => c + n) 
										)
								)
					);
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			var results = new List<string> { "" }; //Empty to start
			var list = results
				.AddPossibilities("h", @""   , 1, 2)
				.AddPossibilities("m", @"\:" , 1, 2)
				.AddPossibilities("s", @"\:" , 1, 2)
				.AddPossibilities("f", @"\." , 0, 3);
			
			var timeSpan = new TimeSpan(0,1,2,3,4);
			foreach (var s in list)
			{
				Console.WriteLine(timeSpan.ToString(s));
			}
		}
	}
