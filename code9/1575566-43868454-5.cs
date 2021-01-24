	var testResult = Observable.Generate(0, i => true, i => i + 1, i => i)
		.Repeat()
		.TakeWhile(l => l < 3)
		;
	testResult.Subscribe(b => Console.WriteLine(b), e => { }, () => Console.WriteLine("OnCompleted"));
	Console.WriteLine("This is printed.");
