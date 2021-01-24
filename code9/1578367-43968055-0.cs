    StringBuilder listSB = new StringBuilder();
    int lineNumber = 0;
    while(reader.Read()) 
    {
        lineNumber++; 
        string vertaling = "";
    	if (reader.Read()) 
    	{
    		vertaling = $"{reader["vertaling"]}";
    	}
    
    	if (!vertaling.Equals(""))
    	{
    		listSB.Append(listSB.Length > 0 ? "\n": "").Append(lineNumber).Append(". ").Append(vertaling);
    	}
    }
    
    if (listSB.Length > 0)
    {
    	lblTest.Text = listSB.ToString();
    }
    else 
    {
    	lblTest.Text = geenvertaling;
    }
