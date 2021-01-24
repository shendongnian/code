    public async Task<HttpResponseMessage> Get()
    {
      return new HttpResponseMessage()
      {
        Content = new StringContent(await LongOperationAsync())
      };
    }
    private async Task<string> LongOperationAsync()
    {
      //long operation here
      await Task.Delay(1000);
      return "HelloWorld";
    }
