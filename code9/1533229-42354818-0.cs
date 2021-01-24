    private static readonly HttpClient client = new HttpClient();
    public async Task DownloadProcedureAsync(long contentLength, IProgress<double> progress)
    {
      long totalBytesReceived = 0;
      int bytesRead = 0;
      byte[] buffer = new byte[10 * 1024];
      using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
      using (var remoteStream= await response.Content.ReadAsStreamAsync())
      {
        while ((bytesRead = await remoteStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
          totalBytesReceived += bytesRead;
          double newProgress = (totalBytesReceived * 100d / contentLength);
          progress?.Report(newProgress);
        }
      }
    }
