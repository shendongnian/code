	public class Size
	{
		public string human { get; set; }
		public int bytes { get; set; }
	}
	
	public class Date
	{
		public string human { get; set; }
		public int epoch { get; set; }
	}
	
	public class RootObject
	{
		public string name { get; set; }
		public Size size { get; set; }
		public Date date { get; set; }
	}
