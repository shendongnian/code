    	Observable.Using(() => 
        {
            var webClient = new WebClient();
            webClient.Headers.Add("User-Agent: Other");
            return webClient;
        }, webClient =>
		Observable.Using(() => 
			Observable.FromEventPattern<DownloadProgressChangedEventHandler, DownloadProgressChangedEventArgs>(
					h => webClient.DownloadProgressChanged += h,
					h => webClient.DownloadProgressChanged -= h
				)
				.Select(ep => ep.EventArgs)
				.Subscribe(dpcea => Console.WriteLine($"{dpcea.ProgressPercentage}% complete. {dpcea.BytesReceived} bytes received. {dpcea.TotalBytesToReceive} bytes to receive.")),
            sub1 => Observable.Using(() =>
				Observable.FromEventPattern<AsyncCompletedEventHandler, AsyncCompletedEventArgs>(
						h => webClient.DownloadFileCompleted += h,
						h => webClient.DownloadFileCompleted -= h
					)
					.Select(ep => ep.EventArgs)
					.Subscribe(_ => Console.WriteLine("Download file complete.")),
				sub2 => webClient.DownloadFileTaskAsync(new Uri(@"http://google.com"), @"C:\temp\temp.txt").ToObservable()
			)
		)
	)
		.Subscribe(_ => {} ); //Subscription required to trigger nested observables
