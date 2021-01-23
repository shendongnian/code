        Task<string> getDataTask = GetData();
	    if (!string.IsNullOrEmpty(getDataTask.Result))
	    {
	    	List<string> results = new List<string>();
	    	dynamic finalResult = JObject.Parse(getDataTask.Result);
	    	results.Add(finalResult.selectedProfile.name);
	    }
