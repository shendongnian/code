            try
			{
				 
				String URL = "http://api.gdax.com/products/BTC-USD/book?level=2";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);				
				request.UserAgent = ".NET Framework Test Client";
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				
			}
			catch(WebException ex)
			{
				HttpWebResponse xyz = ex.Response as HttpWebResponse;
				var encoding = ASCIIEncoding.ASCII;
				using (var reader = new System.IO.StreamReader(xyz.GetResponseStream(), encoding))
				{
					string responseText = reader.ReadToEnd();
				}
			}
