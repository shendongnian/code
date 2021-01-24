    private static void TestGet()
    {
    	Console.WriteLine("[TestGet]\n");
    
    	const string soapMsg = @"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""
    			xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance""
    			xmlns:xsd=""http://www.w3.org/1999/XMLSchema"">
    			<SOAP-ENV:Body>
    				<TestGet xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" />
    			</SOAP-ENV:Body>
    		</SOAP-ENV:Envelope>";
    
    	PerformSOAPRequest(URL, "TestGet", soapMsg);
    }
    
    public static void PerformSOAPRequest(string _url, string _method, string xml_message)
    {
    	HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_url);
    	webRequest.Accept = "text/xml";
    	webRequest.ContentType = "text/xml;charset=\"utf-8\"";
    	webRequest.Headers.Add(@"SOAPAction", string.Format("http://tempuri.org/IService1/{0}", _method));
    	webRequest.Method = "POST";
    
    	byte[] bytes = Encoding.UTF8.GetBytes(xml_message);
    
    	webRequest.ContentLength = bytes.Length;
    
    	using (Stream putStream = webRequest.GetRequestStream())
    	{
    		putStream.Write(bytes, 0, bytes.Length);
    	}
    
    	using (WebResponse response = webRequest.GetResponse())
    	using (StreamReader rd = new StreamReader(response.GetResponseStream()))
    	{
    		string soapResult = rd.ReadToEnd();
    
    		Console.WriteLine(soapResult);
    	}
    }
