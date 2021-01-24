        bool isLast = rdr.Read();
        while(isLast)
    	{
    		string firstCol = rdr[0].ToString();
    		string secondCol = rdr[1].ToString();
    		isLast = rdr.Read();
    		if(!isLast)
    		{
    			Console.WriteLine(firstCol+"--"+secondCol);
    			break;
    		}
    	}
