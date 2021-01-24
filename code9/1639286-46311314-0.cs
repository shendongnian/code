    public async Task MyAsyncWrapper()
    {
      var allTasks = Requests.Select(ProcessRequest);
    
      await Task.WhenAll(allTasks);
    }
    
    private async Task ProcessRequest(Request request)
    {
        KeyValuePair<bool, string> Result = await this.ExecuteAsync(request);
    
        if (Result.Key == true)
        {
          await this.DoSomethingElseAsync(request.Id, request.Name, Result.Value);
          Console.WriteLine("COMPLETED");
        }
    }
