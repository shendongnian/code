        public static string HTTPGET(string url)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
				request.Timeout = 100000;
				HttpWebResponse response = (HttpWebResponse) request.GetResponse();
				Stream responseStream = response.GetResponseStream();
				if (responseStream != null)
					using (StreamReader resStream = new StreamReader(responseStream))
						return resStream.ReadToEnd();
				return null;
			}
			catch (Exception e)
			{
				Console.WriteLine(url);
				Console.WriteLine(e);
				return null;
			}
		}
		public static string HTTPPOST(string url, string postData)
		{
			try
			{
				HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);
				webRequest.Method = "POST";
				webRequest.ContentType = "x-www-form-urlencoded";
				byte[] byteArray = Encoding.UTF8.GetBytes(postData);
				using (Stream requestStream = webRequest.GetRequestStream())
					requestStream.Write(byteArray, 0, byteArray.Length);
				using (Stream responseStream = webRequest.GetResponse().GetResponseStream())
					if (responseStream != null)
						using (StreamReader responseReader = new StreamReader(responseStream))
							return responseReader.ReadToEnd();
				return null;
			}
			catch (Exception e)
			{
				Console.WriteLine(url);
				Console.WriteLine(postData);
				Console.WriteLine(e);
				return null;
			}
		}
