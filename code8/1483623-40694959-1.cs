    public async Task<long> SomeMethodAsync(string url, CancellationToken cancellationToken) {
        var request = (HttpWebRequest) WebRequest.Create(url);
        using (cancellationToken.Register(() => request.Abort(), false)) {
            try {
                var response = await request.GetResponseAsync();
                return response.ContentLength;
            }
            catch (WebException ex) {
                if (cancellationToken.IsCancellationRequested)
                    throw new OperationCanceledException(ex.Message, ex, cancellationToken);
                throw;
            }
        }
    }
