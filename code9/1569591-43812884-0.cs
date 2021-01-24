	private void MakeRequests()
	{
		HttpWebResponse response;
		if (RequestEbay(out response))
		{
			response.Close();
		}
	}
	private bool RequestEbay(out HttpWebResponse response)
	{
		response = null;
		try
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.ebay.com/ws/api.dll");
			request.Headers.Add("X-EBAY-API-SITEID", @"0");
			request.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL", @"967");
			request.Headers.Add("X-EBAY-API-CALL-NAME", @"GetOrders");
			request.Method = "POST";
			request.ServicePoint.Expect100Continue = false;
			string body = @"<?xml version=""1.0"" encoding=""utf-8""?>
			<GetOrdersRequest xmlns=""urn:ebay:apis:eBLBaseComponents"">
			  <RequesterCredentials>
				<eBayAuthToken>!!!!!!!!!!!!!!!!YOUR EBAY TOKEN!!!!!!!!!!!!!!!!1</eBayAuthToken>
			  </RequesterCredentials>
			 <ErrorLanguage>en_US</ErrorLanguage>
			 <WarningLevel>High</WarningLevel>
			  <CreateTimeFrom>2016-12-01T19:09:02.768Z</CreateTimeFrom>
			  <CreateTimeTo>2017-12-15T19:09:02.768Z</CreateTimeTo>
			  <OrderRole>Seller</OrderRole>
			</GetOrdersRequest>";
					byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
					request.ContentLength = postBytes.Length;
					Stream stream = request.GetRequestStream();
					stream.Write(postBytes, 0, postBytes.Length);
					stream.Close();
					response = (HttpWebResponse)request.GetResponse();
		}
		catch (WebException e)
		{
			if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
			else return false;
		}
		catch (Exception)
		{
			if(response != null) response.Close();
			return false;
		}
		return true;
	}      
