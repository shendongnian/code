		public Task Display (CancellationTokenSource tokenSource)
		{
			if (tokenSource == null)
				throw new ArgumentNullException(paramName: "tokenSource");
			var ct = tokenSource.Token;
			return Task.Run (
				() =>
				{
					var i = 0;
					while (!ct.IsCancellationRequested)
					{
						Console.Write ($"\r{productName} {loadingText} {spinner[i]}");
						i = (i + 1) % spinner.Length;
						Thread.Sleep (millisecondsDelay);
					}
				},
				cancellationToken: ct);
		}
		var tokenSource = new CancellationTokenSource();
		var display = consoleLoadingText.Display(tokenSource);
		// Emulate some work
		Thread.Sleep(10000);
		// No need to use Stop method
		tokenSource.Cancel();
		display.Wait();
		...
