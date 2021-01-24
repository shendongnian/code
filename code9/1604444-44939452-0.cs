    public class Program
	{
		static void Main(string[] args)
		{
			string jsonData = "{\"plans\":[{\"plan_code\":\"UL500\",\"plan_name\":\"Unlimited 500M\",\"days\":1,\"limit\":500,\"coverage\":[{\"country\":\"SE\"},{\"country\":\"BZ\"}]},{\"plan_code\":\"UL1GB\",\"plan_name\":\"Unlimited 1GB\",\"days\":1,\"limit\":1024,\"coverage\":[{\"country\":\"SG\"},{\"country\":\"JP\"}]}]}";
			var tempRecords = JsonConvert.DeserializeObject<RootObject>(jsonData);
		}
	}
	public class RootObject
	{
		public List<plan> plans { get; set; }
	}
	public class plan
	{
		public string plan_code { get; set; }
		public string plan_name { get; set; }
		public int days { get; set; }
		public int limit { get; set; }
		public IList<Country> coverage { get; set; }
	}
	public class Country
	{
		public string country { get; set; }
	}
