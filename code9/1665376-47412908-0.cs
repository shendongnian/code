	var httpWebRequest = (HttpWebRequest) WebRequest.Create(
    "http://localhost/api/services/myApp/commonLookup/TestCallingRemotely");
	httpWebRequest.ContentType = "application/json";
	httpWebRequest.Method = "POST";
	var username = "Aladdin";
	var password = "opensesame";
	var bytes = Encoding.UTF8.GetBytes($"{username}:{password}");
	httpWebRequest.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(bytes)}");
	using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
	{
		string input = "{}";
		streamWriter.Write(input);
		streamWriter.Flush();
		streamWriter.Close();
	}
	var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
