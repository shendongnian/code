	public async Task SearchTwitter(string query)
		{
			var oauth_token = "xxxxxx";
			var oauth_token_secret = "xxxxxx";
			var oauth_consumer_key = "xxxxxx";
			var oauth_consumer_secret = "xxxxxx";
			var baseUrl = "https://api.twitter.com/1.1/search/tweets.json";
			var oauthParameters = new Dictionary<string, string>
			{
				{"oauth_consumer_key", Uri.EscapeDataString(oauth_consumer_key)},
				{"oauth_timestamp", Uri.EscapeDataString(DateTime.UtcNow.ToUnixStringFromDateTime())},
				{"oauth_nonce", Uri.EscapeDataString(Guid.NewGuid().ToString("N"))},
				{"oauth_version", Uri.EscapeDataString("1.0")},
				{"oauth_signature_method", Uri.EscapeDataString("HMAC-SHA1")},
				{"oauth_token", Uri.EscapeDataString(oauth_token)}
			};
			var uri = new Uri(baseUrl + $"?count={Uri.EscapeDataString(100.ToString())}&q={Uri.EscapeDataString(query)}&result_type={Uri.EscapeDataString("recent")}&tweet_mode={Uri.EscapeDataString("extended")}");
			var queryString = uri.AbsoluteUri;
			queryString = queryString.Split('?')[1];
			var queryStringParameters = queryString.Split('&');
			var queryStringParameterDictionary = queryStringParameters.Select(queryStringParameter => queryStringParameter.Split('=')).ToDictionary(keyValue => keyValue[0], keyValue => keyValue[1]);
			var allParameters = queryStringParameterDictionary.Concat(oauthParameters).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
			var sortedParameterString =
				string.Join("&",
					(from parm in allParameters
					 orderby parm.Key
					 select parm.Key + "=" + parm.Value)
						.ToArray());
			var signatureBaseString = "GET&" + Uri.EscapeDataString(baseUrl) + "&" + Uri.EscapeDataString(sortedParameterString);
			var signingKey = Uri.EscapeDataString(oauth_consumer_secret) + "&" + Uri.EscapeDataString(oauth_token_secret);
			string oauth_signature;
			using (HMACSHA1 hasher = new HMACSHA1(Encoding.ASCII.GetBytes(signingKey)))
			{
				oauth_signature = Convert.ToBase64String(hasher.ComputeHash(Encoding.ASCII.GetBytes(signatureBaseString)));
			}
			var headerString = "OAuth " + string.Join(", ", oauthParameters.Select(kv => kv.Key + "=\"" + kv.Value + "\"")) + ", oauth_signature=\"" + Uri.EscapeDataString(oauth_signature) + "\"";
			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
			httpRequestMessage.Headers.Add("Authorization", headerString);
			httpRequestMessage.Headers.ExpectContinue = false;
			var httpResponseMessage = await GetHttpClient().SendAsync(httpRequestMessage);
			var resultString = await httpResponseMessage.Content.ReadAsStringAsync();
		}
