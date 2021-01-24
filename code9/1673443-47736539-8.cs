	await Task.Run(async () =>
	{
		handler = handler ?? new AndroidClientHandler();
		client = client ?? new HttpClient(handler);
		client.DefaultRequestHeaders.Clear();
		client.DefaultRequestHeaders.Add("auth-token", access_token);
		using (var imageStream = ContentResolver.OpenInputStream(data.Data))
		using (var streamContent = new StreamContent(imageStream))
		using (var byteArrayContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
		using (var formDataContent = new MultipartFormDataContent())
		{
			formDataContent.Add(byteArrayContent, "file", "DummyFileName.NotUsedOnServer");
			foreach (var content in formDataContent)
			{
				content.Headers.ContentType = new MediaTypeHeaderValue(ContentResolver.GetType(data.Data));
				break;
			}
			using (var response = await client.PostAsync(url, formDataContent))
			{
				Log.Debug(TAG, $"Post: {response.StatusCode} : {response.IsSuccessStatusCode}");
			}
		}
	}).ContinueWith((task) =>
	{
		Log.Debug(TAG, $"Post: {task.Status}");
		if (task.IsFaulted)
		{
			Log.Error(TAG, $"Post Faulted: {task.Exception.Message}");
			Log.Error(TAG, $"Post Faulted: {task.Exception?.InnerException.Message}");
		}
	});
