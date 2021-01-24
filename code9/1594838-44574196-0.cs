	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace ConsoleApp
	{
		class Program
		{
			static void Main(string[] args)
			{
				List<ConsoleColor> colors = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().ToList();
				foreach (var back in colors)
				{
					Console.BackgroundColor = back;
					foreach (var fore in colors)
					{
						Console.ForegroundColor = fore;
						Console.Write("Test      ");
					}
				}
				Console.ReadLine();
			}
		}
	}
