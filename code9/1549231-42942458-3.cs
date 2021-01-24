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
  
    public static ApiCommonResponse PostApiData<T>(string username, string token, T dataModel, string apiEndPoint = null)
    {
    	var apiCommonResponse = new ApiCommonResponse();
    
    	if (apiEndPoint == null) return null;
    
    	var webRequest = WebRequest.Create(apiEndPoint);
    	webRequest.Method = "POST";
    	webRequest.Timeout = 20000;
    	webRequest.ContentType = "application/json";
    	request.Headers.Add("Authorization", "Bearer " + token);
    	webRequest.Headers.Add("X-Api-Version", "");
    
    	using (var requeststreams = webRequest.GetRequestStream())
    	{
    		using (var sw = new StreamWriter(requeststreams))
    		{
    			sw.Write(JsonConvert.SerializeObject(dataModel));
    		}
    	}
    	try
    	{
    		var httpStatus = (((HttpWebResponse)webRequest.GetResponse()).StatusCode);
    		var httpMessage = (((HttpWebResponse)webRequest.GetResponse()).StatusDescription);
    		using (var s = webRequest.GetResponse().GetResponseStream())
    		{
    			if (s == null) return null;
    
    			using (var sr = new StreamReader(s))
    			{
    				var responseObj = sr.ReadToEnd();
    				if (!string.IsNullOrEmpty(responseObj))
    				{
    					apiCommonResponse = JsonConvert.DeserializeObject<ApiCommonResponse>(responseObj);
    				}
    			}
    			apiCommonResponse.httpStatus = (int)httpStatus;
    			apiCommonResponse.httpErrorMessage = httpMessage;
    			apiCommonResponse.Object = apiCommonResponse.Object;
    
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
    	return apiCommonResponse;
    }
