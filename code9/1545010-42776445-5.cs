	public static class ObservableStreamExtensions
	{
		public static IObservable<byte[]> ToObservable(this Stream source, int bufferSize)
		{
			return Observable.Create<byte[]>(async (o, cts) =>
			{
				var buffer = new byte[bufferSize];
				var bytesRead = 0;
				do 
				{
					try
					{
						bytesRead = await source.ReadAsync(buffer, 0, bufferSize);
						if (bytesRead > 0)
						{
							var output = new byte[bytesRead];
							Array.Copy(buffer, output, bytesRead);
							o.OnNext(output);	
						}
					}
					catch (Exception e)
					{
						o.OnError(e);
					}
				}
				while (!cts.IsCancellationRequested && bytesRead > 0);
				
				if (!cts.IsCancellationRequested && bytesRead == 0)
				{
					o.OnCompleted();
				}
			});
	    }
	}
