            for (int i = 0; i < 500; i++)
            {
                Task.Run(async () =>
                {
                    var request = WebRequest.Create("http://www.stackoverflow.com");
                    var response = (HttpWebResponse)await Task.Factory
                                        .FromAsync<WebResponse>(request.BeginGetResponse,
                                        request.EndGetResponse,
                                        null);
                }
            );
            }
