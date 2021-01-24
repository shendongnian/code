    private async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, 
        TimeSpan? timeout = null)
    {
        if (timeout == null)
            return await _httpClient.SendAsync(request);
        else
        {
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                var sendTask = _httpClient.SendAsync(request);
                while (true)
                {
                    if (sendTask.IsCompleted)
                        break;
                    else
                    {
                        cts.Token.ThrowIfCancellationRequested();
                        Thread.Sleep(10);
                    }
                }
                return await sendTask;
            }
        }
    }
