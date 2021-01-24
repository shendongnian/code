	using (var stream = new MemoryStream(new byte[] { 1, 2, 3 }))
	{
		var testResult = stream
			.AsObservable(1024)
			;
		testResult.Subscribe(b => Console.WriteLine(b), e => {}, () => Console.WriteLine("OnCompleted"));
	}
