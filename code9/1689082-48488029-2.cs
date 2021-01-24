    [FunctionName("Function1")]
    public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
        HttpRequestMessage req, TraceWriter log)
    {
        log.Info("Running");
        var api = new MyApiController();
        var result = await Task.Run(() => api.Get());
        return req.CreateResponse(HttpStatusCode.OK, result);
    }
