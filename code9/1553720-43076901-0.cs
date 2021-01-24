		var expectedMessage = MessageReceived
			.Where(x => x.EndsWith("D") && x.EndsWith("F"))
			.Take(1)
			.Replay(1)
			.RefCount();
		using (var dummySubscription = expectedMessage.Subscribe(i => {}))
		{
			await SendMessage("ABC");
			//Some code... goes here.
			return await expectedMessage;
		}
