    string CSV1 = @"Id	Name	City
    1	Tom	New York
    2	Mark	FairFax";
    
    string CSV2 = @"Id	City
    1	Las Vegas
    2	Dallas";
    
    dynamic rec1 = null;
    dynamic rec2 = null;
    StringBuilder csv3 = new StringBuilder();
    using (var csvOut = new ChoCSVWriter(new StringWriter(csv3))
    	.WithFirstLineHeader()
    	.WithDelimiter("\t")
    	)
    {
    	using (var csv1 = new ChoCSVReader(new StringReader(CSV1))
    		.WithFirstLineHeader()
    		.WithDelimiter("\t")
    		)
    	{
    		using (var csv2 = new ChoCSVReader(new StringReader(CSV2))
    			.WithFirstLineHeader()
    			.WithDelimiter("\t")
    			)
    		{
    			while ((rec1 = csv1.Read()) != null && (rec2 = csv2.Read()) != null)
    			{
    				rec1.City = rec2.City;
    				csvOut.Write(rec1);
    			}
    		}
    	}
    }
    Console.WriteLine(csv3.ToString());
