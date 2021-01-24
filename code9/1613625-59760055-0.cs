    class Program
    {
        private static HttpClientHandler httpClientHandler = new HttpClientHandler();
        private static HttpClient GetHTTPClient()
        {
            HttpClient client = new HttpClient(httpClientHandler);
            return client;
        }
        static void Main(string[] args)
        {
            var tasks = new[]
           {
                Task.Factory.StartNew(() => MakeCalls()),
                Task.Factory.StartNew(() => MakeCalls()),
                Task.Factory.StartNew(() => MakeCalls())
            };
            Task.WaitAll(tasks);
        }
        static void MakeCalls()
        {
            Uri uri = new Uri("http://www.mySiteUrl.com/api/Employee/1");
            var client = GetHTTPClient();
            var httpResponse = client.GetAsync(uri);
            //Do something with httpResponse
        }
    }
