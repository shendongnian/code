    private static async Task<string> CallPsiForPrimaryStats(string url)
    {
      ...
      Task<WebResponse> task = Task.Factory.FromAsync(
          myReq.BeginGetResponse,
          myReq.EndGetResponse,
          (object)null);
      var result = await task;
      return ReadStreamFromResponse(result);
    }
