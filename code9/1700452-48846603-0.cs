    // External api, the callbacks will be from multiple threads
    public class Api
    {
        public static Connect(
            Action<Connection> onConnect,
            Action<Connection> onMessage) 
        {}
    }
    async Task<Connection> ConnectAsync(Action<Message> callback)
    {
        var syncContext = SynchronizationContext.Current;
        var tcs = new TaskCompletionSource<Connection>();
        // use post() to ensure callbacks from other threads are executed thread-safely
        Action<Connection> onConnect = conn => 
        {
            syncContext.Post(o => tcs.SetResult(conn), null);
        };
        Action<Message> onMsg = msg => 
        { 
            syncContext.Post(o => callback(msg), null);
        };
        // call the multi-threaded non async/await api supplying the callbacks
        Api.Connect(onConnect, onMsg);
        return await tcs.Task;
    }
	
	//
	// https://github.com/StephenClearyArchive/AsyncEx.Context
	//
	Nito.AsyncEx.AsyncContext.Run(async () =>
	{
		var connection = await ConnectAsync(
			msg => 
			{ 
				/* this will execute in same thread as ConnectAsync and Send */ 
			});
		await connection.Send("Hello world);
        ... more async/await code
	});
