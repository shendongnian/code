    private RestClient restClient;
        private void InitODataClient()
        {
            restClient = new RestClient(options.BaseUrl);
            restClient.AddDefaultHeader("Authorization", "Bearer " + options.AccessToken);
        }
        private async Task ReadConfigAsync()
        {
                var requestApplication = new RestRequest("Applications/" + Guid.Parse(applicationId));
                var response = await restClient.ExecuteGetTaskAsync<Application>(requestApplication);
    //Here the response contains the underlying connection is closed error
        }
        public async Task RestartAsync()
        {
            Stop();
            do
            {
                try
                {
                    Logger.Log("Trying to reconnect to the server in 5 seconds...");
                    Thread.Sleep(5000);
                    InitODataClient();
                    ReadConfigAsync().Wait();
                    break;
                }
                catch (Exception) { }
            }
            while (true);
        }
