      var callResult = client.StreamGreeting(new CallOptions());
      Task.WhenAll(new[]
      {
        Task.Run(async () =>
        {
          await callResult.RequestStream.WriteAsync(request);
          await callResult.RequestStream.WriteAsync(request);
          await callResult.RequestStream.WriteAsync(request);
          await callResult.RequestStream.WriteAsync(request);
          await callResult.RequestStream.CompleteAsync();
        }),
        Task.Run(async () =>
        {
          while (await callResult.ResponseStream.MoveNext(CancellationToken.None))
          {
            Console.WriteLine(callResult.ResponseStream.Current.Greeting);
          }
        })
      }).Wait();   
