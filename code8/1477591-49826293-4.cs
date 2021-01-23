    StringBuilder csv = new StringBuilder();
    using (var p = new ChoJSONReader(new StringReader(json)))
    {
    	using (var w = new ChoCSVWriter(new StringWriter(csv))
    		.WithFirstLineHeader()
    		)
    	{
    		w.Write(p);
    	}
    }
    
    Console.WriteLine(csv.ToString());
