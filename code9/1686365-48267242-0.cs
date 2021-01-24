    void Main()
	{
		var position1 = new Position1() { Lat = 10, Lon = 5 };
		var position2 = new Position1() { Lat = 12, Lon = 3 };
		Console.WriteLine(GetLatLon(position1));
		Console.WriteLine(GetLatLon(position2));
	}
	
	static string GetLatLon<T>(T input) 
	{
		var position1 = input as Position1;
		var position2 = input as Position2;
		if (position1 != null)
		{
			return $"{position1.Lat}-{position1.Lon}";
		}
		if (position2 != null)
		{
			return $"{position2.Lat}-{position2.Lon}";
		}
		throw new ArgumentException(nameof(input));
	}
	
	class Position1 
	{
		public double Foo { get; set ;}
		public int Lat { get; set;}
		public int Lon { get; set;}
	}
	
	class Position2 
	{
		public int Lat { get; set; }
		public int Lon { get; set; }
	}
