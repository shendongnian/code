    public async Task StartCallingAsync(CancellationToken cancellationToken = (default)CancellationToken)
    {
        while(true)
        {
           var response = await _httpClient.GetAsync(url);
           if (response.IsSuccessStatusCode)
           {
               //do work
           }
           await Task.Delay(10000, cancellationToken);
        }
    }
