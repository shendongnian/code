    void Main()
    {
    	using (var stream = new MemoryStream())
    	using (var writer = new StreamWriter(stream))
    	using (var reader = new StreamReader(stream))
    	using (var csv = new CsvReader(reader))
    	{
    		writer.WriteLine("FirstName,LastName");
    		writer.WriteLine("\"Jon\"hn\"\",\"Doe\"");
    		writer.WriteLine("\"Jane\",\"Doe\"");
    		writer.Flush();
    		stream.Position = 0;
    
    		var good = new List<Test>();
    		var bad = new List<string>();
    		var isRecordBad = false;
    		csv.Configuration.BadDataFound = context =>
    		{
    			isRecordBad = true;
    			bad.Add(context.RawRecord);
    		};
    		while (csv.Read())
    		{
    			var record = csv.GetRecord<Test>();
    			if (!isRecordBad)
    			{
    				good.Add(record);
    			}
    
    			isRecordBad = false;
    		}
    
    		good.Dump();
    		bad.Dump();
    	}
    }
    
    public class Test
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    }
