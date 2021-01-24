			using (var client = new HttpClient())
			{
				using (var content =
					new MultipartFormDataContent("upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
				{
					content.Add(new StringContent("true"), "is_hidden");
					content.Add(new StringContent("[access_token]"), "access_token");
					var response = client.PostAsync(new Uri("https://graph.facebook.com/v2.4/[comment_id]"), 
                                                   content).Result; // You could use await here
				}
			}
