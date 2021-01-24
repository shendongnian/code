         HttpStatusCode status;
        
                    using (var client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromSeconds(10); // candidate for .config setting
                                                                   // client.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);
      
                        //here I use my blob file to test it              
                        var request = new HttpRequestMessage(HttpMethod.Get, "https://xxxxxxxxxx.blob.core.windows.net/media/secondblobtest-eypt.txt");
                        var sendTask =  client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                        var response = sendTask.Result; // not ensuring success here, going to handle error codes without exceptions
                        status = response.StatusCode;
        
                        if (status == HttpStatusCode.OK)
                        {
                            MemoryStream ms = new MemoryStream();
        
                            var httpStream = response.Content.ReadAsStreamAsync().Result;
        
                            httpStream.CopyTo(ms);
                            ms.Position = 0;
                           WriteFile("aaa", "testaa", ms);
                         //   hash = HashGenerator.GetMD5HashFromStream(httpStream);
                        }
                    }
