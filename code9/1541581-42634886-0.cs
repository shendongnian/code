	public static string PostJsonSync(string url, object obj) {		
		var httpWebRequest         = (HttpWebRequest)WebRequest.Create(url);
		httpWebRequest.ContentType = "application/json";
		httpWebRequest.Method      = "POST";
		using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
			var json = JsonConvert.SerializeObject(obj);
			streamWriter.Write(json);
			streamWriter.Flush();
			streamWriter.Close();
		}
		var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
			var result = streamReader.ReadToEnd();
			return result;
		}
	}
