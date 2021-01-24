	private bool Post(<<DataStaructure>> inputParam)
		{
			var jsonSerializerSettings =
				new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
	 
			var client = new RestClient("http://localhost:52733/set/");
			var request = new RestRequest(Method.POST);
			var jsonToSend = JsonConvert.SerializeObject(inputParam, jsonSerializerSettings);
			request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);
			if (response.IsSuccessful == false)
			{
				throw new Exception(response.ErrorMessage);
			}
			else
			{
				return Convert.ToBoolean(response.Content);
			}
		}
