	var firstNameSource = new Subject<FirstNameMessage>();
	var lastNameSource = new Subject<LastNameMessage>();
	var timeout = TimeSpan.FromSeconds(1); //Set to length of time willing to wait
	var join = firstNameSource.Join(lastNameSource,
			fnm => Observable.Timer(timeout),
			lnm => Observable.Timer(timeout),
			(fnm, lnm) => new { FirstNameMessage = fnm, LastNameMessage = lnm }
		)
		.Where(a => a.FirstNameMessage.Id == a.LastNameMessage.Id)
		.Select(a => Tuple.Create(a.FirstNameMessage.Name, a.LastNameMessage.Name))
		.Timeout(timeout)
		.Catch(Observable.Empty<Tuple<string, string>>());
