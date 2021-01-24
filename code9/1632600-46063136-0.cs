        [FunctionName("Function4")]       
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestMessage req,
            [EventHub("%EventHub%", Connection = "connectionEventHub")] IAsyncCollector<string> outputEventHubMessages,
            [Queue("%RetryQueue%")] IAsyncCollector<string> outputQueueRetryMessages,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            // Get request body
            string message = JsonConvert.SerializeObject(JObject.Parse(await req.Content.ReadAsStringAsync()));
            try
            {
                await outputEventHubMessages.AddAsync(message);
                await outputEventHubMessages.FlushAsync();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                //await Task.Delay(5000);
                await outputQueueRetryMessages.AddAsync(message);
            }
           
            return req.CreateResponse(HttpStatusCode.OK);
        }
