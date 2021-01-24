	var message = new HttpRequestMessage(new HttpMethod("POST"), "...");
	message.Headers.TryAddWithoutValidation("If-Match", "*");
	message.Content = new StringContent("{\"a\":\"b\"}");
	message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
	_httpClient.SendAsync(message).GetAwaiter().GetResult();
