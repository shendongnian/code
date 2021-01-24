    IObservable<RepeatingMessage> repeatingMessages; //Fill in
    IObservable<UserMessage> userMessages;  //Fill in, best guess is:
	//	IObservable<UserMessage> userMessages = Observable.FromEventPattern<UserEventArgs>(
	//			h => UserMessageArrived += h, 
	//			h => UserMessageArrived -= h
	//		)
	//		.Select(e => e.EventArgs.UserMessage);
	var final = repeatingMessages
		.Select(rm => rm == null
			? Observable.Never<string>()
			: Observable.Timer(TimeSpan.Zero, rm.Period).Select(_ => rm.Message)
		)
		.Switch()
		.Publish(_repeatStream => userMessages
			.Select(um => Observable.Empty<string>()
				.Delay(um.Cooldown)
				.StartWith(um.Message)
				.Concat(_repeatStream)
			)
			.Switch()
		);
		
