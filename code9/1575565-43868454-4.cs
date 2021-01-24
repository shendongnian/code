	int i = 0;
	var testResult = Observable.FromAsync(() => Task.FromResult(i++))
		.Repeat()
		.TakeWhile(l => l < 3)
		;
	testResult.Subscribe(b => Console.WriteLine(b), e => { }, () => Console.WriteLine("OnCompleted"));
	Console.WriteLine("This is never printed.");
