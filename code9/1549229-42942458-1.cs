    public static ApiCommonResponse GetApiData<T>(string token, T dataModel, string apiEndPoint = null)
    {
    	var responseText = "";
    	var apiCommonResponse = new ApiCommonResponse();
    	if (apiEndPoint != null)
    	{
    		var request = (HttpWebRequest)WebRequest.Create(apiEndPoint);
    		request.Method = "GET";
    		request.ContentType = "application/json";
    		request.Headers.Add("Authorization", "Bearer " + token);
    		request.Headers.Add("X-Api-Version", "");
    		try
    		{
    			var httpResponse = (HttpWebResponse)request.GetResponse();
    			var stream = httpResponse.GetResponseStream();
    			if (stream != null)
    			{
    				using (var streamReader = new StreamReader(stream))
    				{
    					responseText = streamReader.ReadToEnd();
    				}
    			}
    		}
    		catch (WebException we)
    		{
    			var stream = we.Response.GetResponseStream();
    			if (stream != null)
    			{
    				var resp = new StreamReader(stream).ReadToEnd();
    				dynamic obj = JsonConvert.DeserializeObject(resp);
    				throw new Exception(obj.ToString());
    			}
    		}
    	}
    
    	var jsonSettings = new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore };
    	apiCommonResponse.Object = JsonConvert.DeserializeObject<T>(responseText, jsonSettings);
    	apiCommonResponse.httpStatus = 0;
    	return apiCommonResponse;
    }
  
