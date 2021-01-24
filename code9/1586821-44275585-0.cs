    public static async Task<Details> getDetails(string authKey, string AppVersionandBuild)
    {
    
    	var response = await JsonWebCall<Details>.GetDirect(
    	   JsonWebCall<object>.baseURl + "MyApp/GetDetails",
    	   authKey,
    	   AppVersionandBuild);
    
    	return response.Item1;
    }
