	string statusCode;
	string body =
		 "{" +
		  "\"transactionToken\": \"" + transactionToken + "\"," +
		  "\"sessionToken\": \"" + sessionToken + "\"" +
		 "}";
	string requestURL = "https://devapice.vnforapps.com/api.authorization/api/v1/authorization/web/{MyMerchantId}";
	string id = "xxxxxx";
	string password = "yyyyyyy";
	string respuesta = "";
	try
	{
		HttpWebRequest request = WebRequest.Create(requestURL) as HttpWebRequest;
		request.Method = "POST";
		request.ContentType = "application/json";
		request.Accept = "application/json";
		using(var rs = request.GetRequestStream()){
			using(StreamWriter sw = new StreamWriter(rs)){
				sw.Write(body);
			}
		}
		request.Headers["Authorization"] = GetBasicAuthHeader(id, password);
		request.Headers["VisaNet-Session-Key"] = sessionToken;
		using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
		{
			statusCode = response.StatusCode.ToString();
			using(StreamReader sr = new StreamReader(response.GetResponseStream()){
				respuesta = sr.ReadToEnd();
			}
		}
	}
	catch (WebException ex)
	{
		using (WebResponse response = ex.Response)
		{
			var httpResponse = (HttpWebResponse)response;
			using (Stream data = response.GetResponseStream())
			{
				StreamReader sr = new StreamReader(data);
				respuesta = sr.ReadToEnd();
			}
		}
	}
