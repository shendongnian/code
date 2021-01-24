	const string url = "http://10.0.2.2:5000/api/image";
	AndroidClientHandler handler;
	HttpClient client;
	protected async override void OnActivityResult(int requestCode, Result resultCode, Intent data)
	{
		string access_token = "some oauth2 token";
		if (resultCode.HasFlag(Result.Ok) && requestCode == PickImage)
		{
			using (var imageStream = ContentResolver.OpenInputStream(data.Data))
			{
				await Task.Run(async () =>
				{
					handler = handler ?? new AndroidClientHandler();
					client = client ?? new HttpClient(handler);
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth2", access_token);
					client.DefaultRequestHeaders
						.Accept
						.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
					client.Timeout = TimeSpan.FromSeconds(30);
					using (var content = new StreamContent(imageStream))
					using (var response = await client.PostAsync(url, content))
					{
						Log.Debug(TAG, $"Post: {response.StatusCode} : {response.IsSuccessStatusCode}");
					}
				}).ContinueWith((task) =>
				{
					Log.Debug(TAG, $"Post: {task.Status}");
					if (task.IsFaulted)
					{
						Log.Debug(TAG, $"Post Faulted: {task.Exception.Message}");
						Log.Debug(TAG, $"Post Faulted: {task.Exception?.InnerException.Message}");
					}
				});
			}
		}
	}
