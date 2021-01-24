    private static HttpClient client = new HttpClient();
    [FunctionName("CreateRadioAPI")]
    public static async Task<HttpResponseMessage> CreateRadioAPIAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/radio/stats/info")]HttpRequestMessage req, TraceWriter log)
    {
        try
        {
            var responseFromA = await client.GetAsync("https://yoursite.com/a.json");
            var body = await responseFromA.Content.ReadAsStringAsync();
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(body, Encoding.UTF8, "application/json");
            return response;
        }
        catch (Exception ex)
        {
            log.Error("An error occured: ", ex);
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
