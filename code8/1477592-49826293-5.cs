    StringBuilder csv = new StringBuilder();
    using (var p = new ChoCSVReader(new StringReader(json))
    		.WithFirstLineHeader()
    	)
    {
    	using (var w = new ChoJSONWriter(new StringWriter(csv)))
    	{
    		w.Write(p);
    	}
    }
    
    Console.WriteLine(csv.ToString());
