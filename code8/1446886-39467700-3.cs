    static string PostData(string token, List<KeyValuePair<string, string>> lsPostContent)
    {
    	string response = String.Empty;
    	try
    	{
    		using (var client = new HttpClient())
    		{
			    FormUrlEncodedContent cont = new FormUrlEncodedContent(lsPostContent);
    			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    			var resp = client.PostAsync("https://localhost:61086/api/<your API controller>/", cont);
    			resp.Wait(TimeSpan.FromSeconds(10));
	    		if (resp.IsCompleted)
		    	{
			    	if (resp.Result.StatusCode == HttpStatusCode.Unauthorized)
				    {
					    Console.WriteLine("Authorization failed. Token expired or invalid.");
				    }
				    else
				    {
					    response = resp.Result.Content.ReadAsStringAsync().Result;
					    Console.WriteLine(response);
    				}
    			}
	    	}
        }
	    catch (Exception ex)
	    {
	    }
    	return response;
    }
