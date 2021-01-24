    public static IObservable<TcpClient> ToListenerObservable(
        this TcpListener listener,
        int backlog)
    {
        return Observable.Create<TcpClient>(async (observer, token) =>
        {
            listener.Start(backlog)
            try
            {
                while (!token.IsCancellationRequested)
                {
                    observer.OnNext(await listener.AcceptTcpClientAsync()
                        .WithCancellation(token));
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Completing...");
                observer.OnCompleted();
            }
            catch (System.Exception error)
            {
                observer.OnError(error);
            }
            finally
            {
                Console.WriteLine("Stopping listener...");
                listener.Stop();
            }
        });
    }
