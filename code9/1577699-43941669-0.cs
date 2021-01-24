	var letters = new Subject<string>();
	var numbers = new Subject<string>();
	var predicate = lettersPublished.Select(s => s.All(c => char.IsLower(c)));
	var numbersCached = numbers.Replay().RefCount();
	
	var dummySubscription = numbersCached.Subscribe();
	var combined = lettersPublished.Merge(numbersCached);
	var switchFlag = predicate.Where(b => b).Take(1);
	var result = switchFlag.StartWith(false).Select(b => b ? combined : letters).Switch();
	
	var resultWithDisposal = Observable.Using(() => dummySubscription, _ => result);
