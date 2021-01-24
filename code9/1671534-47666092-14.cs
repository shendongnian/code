	var url = "https://self-signed.badssl.com";
	using (var selfSignedDelegate = new SelfSignedSessionDataDelegate())
	using (var session = NSUrlSession.FromConfiguration(NSUrlSession.SharedSession.Configuration, (INSUrlSessionDelegate)selfSignedDelegate, NSOperationQueue.MainQueue))
	{
		var request = await session.CreateDataTaskAsync(new NSUrl(url));
		var cSharpString = NSString.FromData(request.Data, NSStringEncoding.UTF8);
		Console.WriteLine(cSharpString);
	}
