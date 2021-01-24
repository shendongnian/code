    public static Task<HttpResponseMessage> InvokeRequestResponseService( string pstrRequest)
    {
        ServiceConnect objServiceConnect = new ServiceConnect();
        using (var client = new HttpClient())
        {
            var scoreRequest = new
            {
                Inputs = new Dictionary<string, InputOutputTable>() {
                    {
                        "input1",
                        new InputOutputTable()
                        {
                            ColumnNames = new string[] {"Assignment group", "Short description"},
                            Values = new string[,] {  { "", pstrRequest },  { "", "" },  }
                        }
                    },
                },
                GlobalParameters = new Dictionary<string, string>()
                {
                }
            };
            const string apiKey = "Some API Key"; // Replace this with the API key for the web service
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            client.BaseAddress = new Uri("Some Uri");
            // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
            // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
            // For instance, replace code such as:
            //      result = await DoSomeTask()
            // with the following:
            //      result = await DoSomeTask().ConfigureAwait(false)
            return client.PostAsJsonAsync("", scoreRequest);
        }
    }
