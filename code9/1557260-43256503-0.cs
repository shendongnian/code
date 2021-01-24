    public async void DownloadWithTracking(string argFilePath)
        {
            var aFileName = Path.GetFileName(argFilePath);
            string anAccessToken = "";
            var aHttpClient = new HttpClient(new WebRequestHandler { ReadWriteTimeout = 10 * 1000 }) { Timeout = TimeSpan.FromMinutes(20) };
            var aDorpboxConfig = new DropboxClientConfig("DownloadApp") { HttpClient = aHttpClient };
            using (var aDropboxClient = new DropboxClient(anAccessToken, aDorpboxConfig))
            {
                var aResponse = await aDropboxClient.Files.DownloadAsync(argFilePath);
                ulong aFileSize = aResponse.Response.Size;
                const int aBufferSize = 4 * 1024 * 1024;
                var aBuffer = new byte[aBufferSize];
                using (var aDropboxContentStream = await aResponse.GetContentAsStreamAsync())
                {
                    Response.BufferOutput = false;
                    Response.AddHeader("content-disposition", "attachment;filename=" + aFileName);
                    Response.AddHeader("Content-Length", aFileSize.ToString());
                    int aLengthOfBytesRead = aDropboxContentStream.Read(aBuffer, 0, aBufferSize);
                    while (aLengthOfBytesRead > 0)
                    {
                        Response.OutputStream.Write(aBuffer, 0, aLengthOfBytesRead);
                        aLengthOfBytesRead = aDropboxContentStream.Read(aBuffer, 0, aBufferSize);
                    }
                }
            }
        }
