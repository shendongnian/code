    public async Task<loginResponse> Login(loginRequest request)
    {
        var tcs = new TaskCompletionSource<loginResponse>();
        ClientGenerator.WebServiceUrl = _webServiceUrl;
        ClientGenerator.InitializeService();
        client = ClientGenerator.ServiceClient;
        client.loginCompleted += (sender, loginResult) =>
        {
            if (loginResult.Error != null)
                tcs.SetException(loginResult.Error);
            else
                tcs.TrySetResult(loginResult.Result);
        };    
        await client.loginAsync(request);                
        return tcs.Task;
    }
