	var url = "https://self-signed.badssl.com";
	using (var selfSignedDelegate = new SelfSignedSessionDataDelegate())
	using (var session = NSUrlSession.FromConfiguration(NSUrlSession.SharedSession.Configuration, (INSUrlSessionDelegate)selfSignedDelegate, NSOperationQueue.MainQueue))
	using (var handler = new NSUrlSessionHandler(session))
	using (var httpClient = new HttpClient(handler))
	using (var response = await httpClient.GetAsync(url))
	using (var content = response.Content)
	{
		var result = await content.ReadAsStringAsync();
		Console.WriteLine(result);
	}
