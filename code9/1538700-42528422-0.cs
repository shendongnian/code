	using System;
	using Newtonsoft.Json;
						
	public class Program
	{
		static string textdata = @"{
	  ""Points"": [
		{
		  ""X"": -3.05154,
		  ""Y"": 4.09
		},
		{
		  ""X"": -3.05154,
		  ""Y"": 3.977
		}
	  ],
	  ""Rectangles"": [
		{
		  ""XMin"": -3.08154,
		  ""XMax"": 3.08154,
		  ""YMin"": -4.5335,
		  ""YMax"": 4.5335
		}
	  ]
	}";
		
		public static void Main()
		{
			var data = JsonConvert.DeserializeObject<Data>( textdata );
			Console.WriteLine( "Found {0} points", data.Points.Length );
			Console.WriteLine( "With first point being X = {0} and Y = {0}", data.Points[0].X, data.Points[0].Y);
		}
	}
	
	public class Data {
		public Point[] Points { get; set; }
	}
	
	public class Point {
		public decimal X { get; set; }
		public decimal Y { get; set; }
	}
