     byte[] bytes = System.IO.File.ReadAllBytes(@"EXCEL_FILE_PATH");
        string listA = "";
        while (!reader.EndOfStream)
        	{
        		var line = reader.ReadLine();
        		listA = listA + line + "\n";
        	}
        byte[] bytes = Encoding.ASCII.GetBytes(listA);
        request.Body = new MemoryStream(bytes);
        InvokeEndpointResponse response = sagemakerRunTimeClient.InvokeEndpoint(request);
        string predictions = Encoding.UTF8.GetString(response.Body.ToArray());
