	using (var client = new HttpClient())
	{
		var streamContent = new StreamContent(someImageFileStream);
		streamContent.Headers.Add("Content-Disposition",
			new string(Encoding.UTF8.GetBytes("form-data; name=\"image\"; filename=\"Тест.jpg\"").
			Select(b => (char)b).ToArray()));
		var content = new MultipartFormDataContent();
		content.Add(streamContent);
		await client.PostAsync("http://localhost.fiddler/", content);
	}
