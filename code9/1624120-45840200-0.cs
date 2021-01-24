	public string PostData(string body, string url)
	{
		string responseText = null;
		try
		{
			var uri = new Uri(string.Format(_host + url, string.Empty));
			var webRequest = WebRequest.Create(uri) as HttpWebRequest;
			webRequest.Headers.Add("Cookie", GlobalConfig.SessionId);
			webRequest.Headers.Add("_RequestVerificationToken", GlobalConfig.Token);
			webRequest.Method = "POST";
			webRequest.ContentType = "application/xml";
			using (Stream requestStream = webRequest.GetRequestStream())
			{
				using (StreamWriter writer = new StreamWriter(requestStream))
				{
					writer.Write(body);
				}
			}
			var webResponse = webRequest.GetResponse() as HttpWebResponse;
			using (Stream responseStream = webResponse.GetResponseStream())
			{
				using (StreamReader reader = new StreamReader(responseStream))
				{
					responseText = reader.ReadToEnd();
				}
			}
		}
		catch (Exception exception)
		{
			Console.WriteLine(exception);
		}
		return responseText;
	}
