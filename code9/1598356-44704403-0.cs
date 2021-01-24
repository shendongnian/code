	public class RootObject
	{
		public Stations Stations { get; set; }
	}
	
	public class Stations
	{
		public List<Station> From { get; set; }
		public List<Station> To { get; set; }
	}
	
	
	public class Station
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int? Score { get; set; }
		public Coordinate Coordinate { get; set; }
		public double? Distance { get; set; }
	}
	
	public struct Coordinate
	{
		public string Type { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
	}
