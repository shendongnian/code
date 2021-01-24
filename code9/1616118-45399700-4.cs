    class Numbers {
		public int Rounded { get; set; }
		public double Number { get; set; }
		public double Difference => Math.Abs(Rounded - Number);
	}
	class Program
	{
		static void Main(string[] args)
		{
			var numbers = new [] {10.15, 14.45, 19.65, 22.18, 27.89, 30.15, 31.15, 37.46, 42.01};
			var decades = new List<Numbers>();
			foreach (var number in numbers)
			{
				var rounded = (int)Math.Round(number / 10, MidpointRounding.AwayFromZero) * 10;
				var found = decades.FirstOrDefault(x => x.Rounded == rounded);
				if (found == null)
					decades.Add(new Numbers { Rounded = rounded, Number = number });
				else if (found.Difference > Math.Abs(rounded - number))
					found.Number = number;
				else if (found.Number > number)
					decades.Add(new Numbers { Rounded = rounded, Number = number });
			}
			foreach (var number in decades)
				Console.WriteLine($"{number.Rounded} from {number.Number}");
			Console.ReadKey();
		}
	}
