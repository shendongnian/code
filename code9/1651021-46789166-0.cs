    var clt = new CancellationTokenSource(5000);
    Task.Run(() => DoSomething(clt.Token));
    
    private static void DoSomething(CancellationToken cltToken)
    {
        for (int depth = 2; !cltToken.IsCancellationRequested; depth += 2)
        {
            // . . .
        }
        if (cltToken.IsCancellationRequested) {
			// Time limit reached before finding best move at this depth
		}
    }
