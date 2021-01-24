    public static async Task<string> PastebinSharpAsync(string Username, string Password)
    {
    	using (HttpClient client = new HttpClient())
    	{
    		var postParams = new Dictionary<string, string>();
    
    		postParams.Add("api_dev_key", IDevKey);
    		postParams.Add("api_user_name", Username);
    		postParams.Add("api_user_password", Password);
    
    		using(var postContent = new FormUrlEncodedContent(postParams))
    		using (HttpResponseMessage response = await client.PostAsync(GlobalVars.IPostURL, postContent))
    		{
    			response.EnsureSuccessStatusCode(); // Throw if httpcode is an error
    			using (HttpContent content = response.Content)
    			{
    				string result = await content.ReadAsStringAsync();
    				Debug.WriteLine(result);
    				return result;
    			}
    		}
    	}
    }
