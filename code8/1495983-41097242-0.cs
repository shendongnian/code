	void Main()
	{
		var cars = new List<Car> 
		{ 
			new Car { Make = "Ferrari", Model = "F50", ServiceCost = 1000 },
			new Car { Make = "Ferrari", Model = "F50", ServiceCost = 2000 },
			new Car { Make = "Porsche", Model = "911", ServiceCost = 2000 }
		};
		var grouped = cars.GroupBy(car => car.Make + car.Model).Select(g => new { g.Key, Costs = g.Sum(e => e.ServiceCost), Element = g.First() });
		foreach (var g in grouped)
		{
			Console.WriteLine("{0} {1}: {2}", g.Element.Make, g.Element.Model, g.Costs);
		}
	}
	
	class Car
	{
		public string Model { get; set; }
		
		public string Make { get; set; }
		
		public decimal ServiceCost { get; set; }	
	}
