        static void Main(string[] args)
        {
            var myjason = new myJsonClass
         {
    	Request = new requestClass
    	{
    		md5 = "da855ff838250f45d528a5a05692f14e",
    		file_name = "MyFile.docx",
    		file_type = "docx",
    		features = new[] { "te" },
    		te = new te
    		{
    			reports = new[] { "pdf", "xml" },
    			images = new a[] { new a { id = "7e6fe36e-889e-4c25-8704-56378f0830df", revision = 1 }, new a { id = "e50e99f3-5963-4573-af9e-e3f4750b55e2", revision = 1 } }
    		},
    
    	}
    };
    
    string json = JsonConvert.SerializeObject(myjason, Newtonsoft.Json.Formatting.Indented);
    Console.WriteLine(json);
            }
    
    public class myJsonClass
    {
    	[JsonProperty("request")]
    	public requestClass Request { get; set; }
    }
    
    public class requestClass
    {
    	public string md5 { get; set; }
    	public string file_name { get; set; }
    	public string file_type { get; set; }
    	public string[] features { get; set; }
    
    	public te te { get; set; }
    
    }
    
    public class a
    {
    	public string id { get; set; }
    	public int revision { get; set; }
    }
    
    public class te
    {
    	public string[] reports { get; set; }
    	public a[] images { get; set; }
    }
