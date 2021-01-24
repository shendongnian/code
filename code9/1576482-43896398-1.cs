	private void Save(List<int> Ids)
	{
		var myAPI = ConfigurationManager.AppSettings["MyAPI"];
		using (var client = new HttpClient())
		{
			var requestBody = JsonConvert.SerializeObject(Ids);
			var postRequest = new StringContent(requestBody, Encoding.UTF8, "application/json");
			var response = client.PostAsync(myAPI, postRequest).GetAwaiter().GetResult();
			var rawResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			// Do something with the answer
		}
	}
