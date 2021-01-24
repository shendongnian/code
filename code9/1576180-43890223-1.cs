      using System.Threading;
      using System.Threading.Tasks;
      ... 
      // 2 minutes = 2 * 60 * 1000 milliseconds
      using (CancellationTokenSource cts = new CancellationTokenSource(2 * 60 * 1000)) {
        CancellationToken token = cts.Token;
        try {
          Task task = Task.Run(() => {
            //TODO: put relevant code here 
            ...
            // Cancellation is a cooperative, that's why do not forget to check the token 
            token.ThrowIfCancellationRequested(); 
            ... 
            }, 
          token);
          await task; 
        }
        catch (TaskCanceledException) {
          // Task has been cancelled due to timeout
          //TODO: put relevant code here 
        }
      }
