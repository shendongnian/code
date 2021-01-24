    public async Task<bool> Login(string ID, string IDPayload, string TenantID)
    {
       .
       .
       var Response = await httpClient.PostAsync(URI,Content);
       return Response.IsSuccessStatusCode;
    }
    private async Task HandleSubmitCommand()
    {
       IsBusy = true;
       //call the login operation asynchronously
       _statusResponse = await DependencyService.Get<IWebService>().Login(_entryFieldType, IdentityDriver, App.TenantId.Value.ToString());
       IsBusy = false;
    }
