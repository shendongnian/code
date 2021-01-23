    try
		{
			HttpClient client = new HttpClient();
			var uri = new Uri("http://localhost/RegisterDevice");
			string data = "{\"username\": \"ADMIN\",\"password\": \"123\"}";
			var content = new StringContent(data, Encoding.UTF8, "application/json");
			HttpResponseMessage response = null;
			response = await client.PostAsync(uri, content);
			Util.HideLoading();
			if (response.IsSuccessStatusCode)
			{
				System.Diagnostics.Debug.WriteLine(@"Success");
			}
			else
			{
				System.Diagnostics.Debug.WriteLine(@"Fail");                
			}
		}
		catch (Exception ex)
		{
		  
		}
