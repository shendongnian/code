	var options = new FeedOptions() { MaxItemCount = 20 };//If 20 is your page size
	var continuationToken = string.Empty;
	var allResults = new List<User>();
	do{
		if (!string.IsNullOrEmpty(continuationToken))
        {
                options.RequestContinuation = continuationToken;
		}
		var userQuery = _client.CreateDocumentQuery<User>(_uriUsersCollection, queryStr, options).ToPagedResults();
		continuationToken = userQuery.ContinuationToken;
		allResults.AddRange(userQuery.Results);		
	}while(!string.IsNullOrEmpty(continuationToken));
	
	
