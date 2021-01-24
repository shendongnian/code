    string FolderId;
    string ChangeKey;
    using (StreamReader sr = new StreamReader("c:\\myfile.xml"))
    {
    	string line;
    	while ((line = sr.ReadLine()) != null)
    	{
    		if (line.Contains("<t:FolderId Id="))
    		{
    			try
    			{
    				var lineArray = line.Split('\"');
    				FolderId = lineArray[1];
    				ChangeKey = lineArray[3];
    			}
    			catch
    			{
    				// handle exception
    			}   			
    		}
    	}
    }
