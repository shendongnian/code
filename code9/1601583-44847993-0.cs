	RestRequest request = 
        new RestRequest($@"api/v4/projects/{project.id}/repository/commits", Method.POST);
	request.Parameters.Clear();
	
	request.Parameters.Add(new Parameter() { 
		Name = "application/json", 
		ContentType = "application/json", 
		Type = ParameterType.RequestBody, 
		Value = commit 
	});
	request.Parameters.Add(new Parameter() { 
		Name = "PRIVATE-TOKEN", 
		Type = ParameterType.HttpHeader, 
		Value = ConfigurationManager.AppSettings["GitLabPrivateKey"] 
	});
	
	IRestResponse respone = _restClient.Execute(request);
