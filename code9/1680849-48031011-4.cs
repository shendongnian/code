            var tasks = new List<Task>();
            for (int i = 0; i < 500; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var request = WebRequest.Create("http://www.example.com");
                    var response = (HttpWebResponse)await Task.Factory
                                        .FromAsync<WebResponse>(request.BeginGetResponse,
                                        request.EndGetResponse,
                                        null);
                    Console.WriteLine($"Request {i} status is {response.StatusCode}");
                }));
           }
           try
           {
                // Wait for all the tasks to finish.
                Task.WaitAll(tasks.ToArray());
           }
           catch (AggregateException e)
           {
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
           }
