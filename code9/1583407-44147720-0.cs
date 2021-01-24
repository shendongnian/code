	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				List<Bag> bags = new List<Bag>();
				bags.Add(new Bag("Blue", 25));
				bags.Add(new Bag("Red", 35));
				bags.Add(new Bag("White", 30));
				int totalVolume = CalcTotalVolume(bags);
				Console.WriteLine("Total volume of bags: {0}", totalVolume);
				Console.ReadKey(true);
			}
			static int CalcTotalVolume(IEnumerable<Bag> bags)
			{
				//resursive method
				//1. base case is when the list is empty
				var bag = bags.FirstOrDefault();
				if (bag == null) return 0;
				var subList = bags.Skip(1);
				return bag.Volume + CalcTotalVolume(subList);
			}
		}
		class Bag
		{
			public string Colour { get; set; }
			public int Volume { get; set; }
			public Bag(string co, int vo)
			{
				Colour = co;
				Volume = vo;
			}
		}
	}
