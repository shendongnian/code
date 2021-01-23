    public async Task<HttpResponseMessage> process(string image)
    {
      var task = DownloadFromBlobAsync(image);
      var setupData = DoSomeSetup();
      var image = await task;
      return DrawTextOnImage(image, setupData);
    }
