    private static HttpClient client = new HttpClient();
    [FunctionName("CreateRadioAPI")]
    public static async Task<HttpResponseMessage> CreateRadioAPIAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/radio/stats/info")]HttpRequestMessage req, TraceWriter log)
    {
        try
        {
            var responseFromA = await client.GetAsync("https://www.google.com");
            var body = await responseFromA.Content.ReadAsStringAsync();
            return req.CreateResponse(HttpStatusCode.OK, body);
        }
        catch (Exception ex)
        {
            log.Error("An error occured: ", ex);
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
