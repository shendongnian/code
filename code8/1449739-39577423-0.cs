    void Main()
    {
    	using (var stream = new MemoryStream())
    	using (var reader = new StreamReader(stream))
    	using (var writer = new StreamWriter(stream))
    	using (var csv = new CsvWriter(writer))
    	{
    		var options = new TypeConverterOptions
    		{
    			Format = "o"
    		};
    		TypeConverterOptionsFactory.AddOptions<DateTime>(options);
    		
    		csv.WriteField(DateTime.Now);
    		csv.NextRecord();
    		writer.Flush();
    		stream.Position = 0;
    		
    		reader.ReadToEnd().Dump();
    	}
    }
