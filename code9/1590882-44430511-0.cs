	public void DoSomeWork()
	{
		PerformWebWork("http://example.com", new object());
		// Perform other work
		// Forget webWork Task
		// Finish
	}
	public async Task DoSomeWorkAsync()
	{
		Task webWorkTask = PerformWebWork("http://example.com", new object());
		// Perform other work
		// Ensure webWorkTask finished
		await webWorkTask;
		// Finish
	}
	public async Task PerformWebWork(string url, object objAPILog)
	{
		string serializedContent = new JavaScriptSerializer().Serialize(objAPILog);
		using (HttpClient client = new HttpClient())
		{
			StringContent content = new StringContent(serializedContent);
			HttpResponseMessage postResponse = await client.PostAsync(url, content);
		}
	}
