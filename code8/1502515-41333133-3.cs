    public async Task DownloadAsync(Action<bool> callback)
        {
            if (NewerApp == null) return;
            // Your original code.
            HttpClientHandler aHandler = new HttpClientHandler();
            aHandler.ClientCertificateOptions = ClientCertificateOption.Automatic;
            HttpClient aClient = new HttpClient(aHandler);
            aClient.DefaultRequestHeaders.ExpectContinue = false;
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, ServerAddress + "/Apps/");
            string content = "id=" + CurrentApp.EncryptedId() + "&action=download";
            message.Content = new StringContent(content);
            HttpResponseMessage response = await aClient.SendAsync(message,
                HttpCompletionOption.ResponseHeadersRead); // Important! ResponseHeadersRead.
            
            // New code.
            Stream stream = await response.Content.ReadAsStreamAsync();
            MemoryStream memStream = new MemoryStream();
            // Start reading the stream
            var res = stream.CopyToAsync(memStream);
            // While reading the stream
            while (true)
            {
                // Report progress
                this.DownloadedSize = memStream.Length;
                this.Progress = 100.0 * (double)memStream.Length / (double)NewerApp.Filesize;
                // Leave if no new data was read
                if (res.IsCompleted)
                {
                    // Report progress one last time
                    this.DownloadedSize = memStream.Length;
                    this.Progress = 100.0 * (double)memStream.Length / (double)NewerApp.Filesize;
                    
                    break;
                }
            }
            // Get the bytes from the memory stream
            byte[] responseContent = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(responseContent, 0, responseContent.Length);
            
            // Function has ended - return whether the app was donwloaded
            // properly and verified, or not
            callback(HandleResponseToDownloadRequest(responseContent));
        }
