	static XNamespace soapNs = "http://schemas.xmlsoap.org/soap/envelope/";
    static XNamespace topNs = "Company.WebService";
    private System.Net.HttpWebResponse ExecutePost(string webserviceUrl, string soapAction, string postData) {
		var webReq = (HttpWebRequest)WebRequest.Create(webserviceUrl);
		webReq.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;  
		webReq.ContentType = "text/xml;charset=UTF-8";	
		webReq.UserAgent = "Opera/12.02 (Android 4.1; Linux; Opera Mobi/ADR-1111101157; U; en-US) Presto/2.9.201 Version/12.02";
		webReq.Referer = "http://www.company.com";	
		webReq.Headers.Add("SOAPAction", soapAction);
		webReq.Method = "POST";
		var encoded = Encoding.UTF8.GetBytes(postData);
		webReq.ContentLength = encoded.Length;
		var dataStream = webReq.GetRequestStream();
		dataStream.Write(encoded, 0, encoded.Length);
		dataStream.Close();
		System.Net.WebResponse response;
		try { response = webReq.GetResponse(); }
		catch { 
			("Unable to post:\n" + postData).Dump();
			throw;
		}
		return response as System.Net.HttpWebResponse;
	}
