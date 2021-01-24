			try
			{
				// Create HTTP Web Request for the token request
				HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(Values.TokenURL);
				
                byte[] data = Encoding.ASCII.GetBytes("username=" + Username + "&password=" + Password + "&client_id=" + ClientId + "&grant_type=" + GrantType);
				// Set request verb POST, content type and content length (length of data)
				tokenRequest.Method = "POST";
				tokenRequest.ContentType = "application/x-www-form-urlencoded";
				tokenRequest.ContentLength = data.Length;
				// Stream request data
				using (Stream stream = tokenRequest.GetRequestStream())
				{
					stream.Write(data, 0, data.Length);
				}
				// Get the response and read stream to string
				using (WebResponse response = tokenRequest.GetResponse())
				{
					using (Stream stream = response.GetResponseStream())
					{
						using (StreamReader sr = new StreamReader(stream))
						{
							// responseText = sr.ReadToEnd();
							return sr.ReadToEnd();
						}
					}
				}
			}
			catch (WebException ex)
			{
				// Catch error for bad URL (404) or bad request (400) resulting from bad input (username, password, client id, grant type in token request)
				if (ex.Message.Contains("400"))
				{
					// do something for bad request
				}
				else if (ex.Message.Contains("404"))
				{
					// do something for not found
				}
				else
				{
					// unknown error, do something
				}
				return null;
			}
			catch (Exception ex)
			{
				// General Exception
				return null;
			}
		}
