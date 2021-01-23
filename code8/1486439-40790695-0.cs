        string input = "2000-02-02";
    	DateTime dateTime;
    	if (DateTime.TryParse(input, out dateTime))
    	{
            //only print if the parsing was successful
    	    Console.WriteLine(dateTime);
    	}
