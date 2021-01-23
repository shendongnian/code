        class Program
    	{
    		static void Main(string[] args)
    		{
    			string[] csv = new[] { "London,Dubai,4", "Dubai,Mumbai,8", "Dubai,Dhaka,4" };
    			List<model> list = new List<model>();
    
    			foreach (var item in csv)
    			{
    
    				string[] fields = item.Split(',');
    				list.Add(new model
    				{
    					From = fields[0],
    					To = fields[1],
    					Duration = fields[2]
    				});
    			}
    
    			var json = JsonConvert.SerializeObject(list);
    			Console.WriteLine(json);
    			Console.ReadLine();
    
    		}
    	}
    
    	public class model
    	{
    		public string From { get; set; }
    		public string To { get; set; }
    		public string Duration { get; set; }
    	}
