	namespace Api.Helpers
	{
		public static class ApiHelpers
		{
			private static string HttpGet(string url)
			{
				WebRequest request = WebRequest.Create(url);
				request.Credentials = CredentialCache.DefaultCredentials;
				WebResponse response = request.GetResponse();
				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				string responseFromServer = reader.ReadToEnd();
				reader.Close();
				response.Close();
				return responseFromServer;
			}
			public static string HttpPostJson(string url, string json)
			{
				var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(json);
				}
				var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
				{
					var result = streamReader.ReadToEnd();
					return result;
				};
			}
		}
	}
