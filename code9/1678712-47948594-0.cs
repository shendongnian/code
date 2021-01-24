    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, string path, TraceWriter log) {
        // ... determine the blob you want to download ...
        var response = HttpResponseMessage(HttpStatusCode.Redirect);
        response.Headers.Location = new Uri(/* Azure blob URI goes here */);
        return response;
    }
