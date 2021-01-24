        static void Main(string[] args)
        {
        	myJson myjson = new myJson
        	{
        		md5 = "8dfa1440953c3d93daafeae4a5daa326",
        		file_name = "example.xls",
        		features = new[] { "te", "av", "extraction" },
        		te = new te { reports = new[] { "xml", "pdf" } },
        		extraction = new ext { method = "pdf" }
        	};
        	string json = JsonConvert.SerializeObject(myjson, Newtonsoft.Json.Formatting.Indented);
        	Console.WriteLine(json);
        }
        
        public class myJson
        {
        	public string md5 { get; set; }
        	public string[] features { get; set; }
        	public string file_name { get; set; }
        	public te te { get; set; }
        	public ext extraction { get; set; }
        }
        
        public class te
        {
        	public string[] reports { get; set; }
        }
        
        public class ext
        {
        	public string method { get; set; }
        }
