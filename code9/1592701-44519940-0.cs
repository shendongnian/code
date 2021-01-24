    try
    {
    	var file = await PCLStorage.FileSystem.Current.LocalStorage.GetFileAsync(device.ClientCodePhoto);
    	using(Stream fileStream = await file.OpenAsync(PCLStorage.FileAccess.Read))
    	using(var client = new HttpClient())
    	using(var content = new MultipartFormDataContent())
    	{
    		content.Add(new StreamContent(fileStream), "client_code_image", "upload.jpg");
    
    		var values = new[]
    		{
    			new KeyValuePair<string, string>("client_code", device.ClientCode),
    			new KeyValuePair<string, string>("registered_by", device.RegisteredBy),
    			new KeyValuePair<string, string>("notes", device.Notes ?? string.Empty),
    			new KeyValuePair<string, string>("sim_code", device.SimCode),
    			new KeyValuePair<string, string>("qr_codes", device.QrCodes)
    		};
    
    		foreach(var keyValuePair in values)
    			content.Add(new StringContent(keyValuePair.Value), string.Format("\"{0}\"", keyValuePair.Key));
    
    		using(var result = await client.PostAsync($"{Constants.Server}devices/", content))
    		{
    			var input = await result.Content.ReadAsStringAsync();
    
    			if(result.IsSuccessStatusCode)
    			{
    				// do something with the result 
    			}
    		}
    	}
    }
    catch(Exception ex)
    {
    	Debug.WriteLine(ex.Message);
    	// something went wrong
    }
