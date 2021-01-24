    public static class MyHttpClientExtensions
	{
		static JsonMediaTypeFormatter CreateJsonMediaTypeFormatter()
		{
			var JsonMediaTypeFormatter = new JsonMediaTypeFormatter();
			// Use the provided JsonContractResolver but reset IgnoreSerializableAttribute
			((DefaultContractResolver)JsonMediaTypeFormatter.SerializerSettings).IgnoreSerializableAttribute = true;
			return JsonMediaTypeFormatter;
		}
		
        public static Task<HttpResponseMessage> MyPostAsJsonAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, CreateJsonMediaTypeFormatter(), cancellationToken);
		}		
		
		// Replace other JSON methods as required.
	}
