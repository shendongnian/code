    public class CrmConnector
    {
        private const string ApiVersion = "v8.2";
        public static HttpClient Client { get; set; }
        public CrmConnector(FileConfiguration config)
        {
            if (Client == null)
            {
                Task.WaitAll(Task.Run(async () => await ConnectToCRM(config)));
            }
        }
        /// <summary>
        /// Obtains the connection information from the application's configuration file, then 
        /// uses this info to connect to the specified CRM service.
        /// </summary>
        protected virtual async Task ConnectToCRM(Configuration config)
        {
            Authentication auth = new Authentication(config);
            Client = new HttpClient(auth.ClientHandler, true);
            Client.BaseAddress = new Uri($"{config.ServiceUrl}api/data/{ApiVersion}/");
            Client.Timeout = new TimeSpan(0, 2, 0);
            Client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            Client.DefaultRequestHeaders.Add("OData-Version", "4.0");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
