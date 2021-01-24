    void SendNetworkRequest(string requestType, Action<Response> callback)
            {
                // This code by third party, this is here just for testing
                if (callback != null)
                { 
                    var result = new Response();
                    callback(result);
                }
            }
    
            Task<Response> SendNetworkRequestAsync(string requestType)
            {
                return Task.Run(() =>
                {
                    var t = new TaskCompletionSource<Response>();
    
                    SendNetworkRequest(requestType, s => t.TrySetResult(s));
    
                    return t.Task;
                });
            }
