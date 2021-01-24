	string apiUri = @"http://localhost:8080/services/rest/index/my_index/document"; // !!!!!
	
	var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUri);
	httpWebRequest.ContentType = "application/json";
	httpWebRequest.Method = "PUT";  
	//httpWebRequest.Accept = "application/json";
	
	using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
	{
		var data = new List<object>()
		{
			new
			{
				Lang = "ENGLISH",
				Fields = new List<object>()
				{
					new { Name = "id", Value = 1 }
				}
			}
	    };
	    string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
	    streamWriter.Write(json);
	}
	var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
	using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
	{
	    var response = Newtonsoft.Json.JsonConvert.DeserializeObject<YourObjectType>(streamReader.ReadToEnd());
	    return response; // do something with the response...
	}
