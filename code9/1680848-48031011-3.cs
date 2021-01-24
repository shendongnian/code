            for (int i = 0; i < 500; i++)
            {
                Task.Run(async () =>
                {
                    var request = WebRequest.Create("http://www.example.com");
                    var response = (HttpWebResponse)await Task.Factory
                                        .FromAsync<WebResponse>(request.BeginGetResponse,
                                        request.EndGetResponse,
                                        null);
                    Console.WriteLine($"Request {i} status is {response.StatusCode}");
                });
           }
