    public static async Task<int> ReadAsync(
            NetworkStream stream, byte[] buffer, int offset, int count, int timeoutMillis)
    {
            if (timeoutMillis < 0) throw new ArgumentException(nameof(timeoutMillis));
            else if (timeoutMillis == 0)
            {
                // No timeout
                return await stream.ReadAsync(buffer, offset, count);
            }
            var cts = new CancellationTokenSource();
            var readTask = stream.ReadAsync(buffer, offset, count, cts.Token);
            var timerTask = Task.Delay(timeoutMillis, cts.Token);
            var finishedTask = await Task.WhenAny(readTask, timerTask);
            var hasTimeout = ReferenceEquals(timerTask, finishedTask);
            // Cancel the timer which might be still running
            cts.Cancel();
            cts.Dispose();
            if (hasTimeout) throw new TimeoutException();
            // No timeout occured
            return readTask.Result;
    }
