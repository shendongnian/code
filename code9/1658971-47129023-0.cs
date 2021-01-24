    public Task<CommunicationMessage> SendAsync(CommunicationMessage query, Action<int> OnReceivedError, Action OnFailedSending) {
        var tcs = new TaskCompletionSource<CommunicationMessage>();
        SendAndReceiveAsync(query, cm => tcs.TrySetResult(cm), OnReceivedError, OnFailedSending);
        return tcs.Task;
    }
    //for BaseUser result
    public static async Task<BaseUser> LoginUserAsync(string email, string password)
    {
        // Create the query which will be sent to the Server
        var query = MessageContentGenerator.GenerateLoginQuery(email, password).Result;
        var result = await SendAsync(query, (errorCode) => {}, () => {});
        return BaseUserController.Parse(result);
    }
