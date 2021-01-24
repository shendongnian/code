    public async Task<HttpResponseMessage> UploadCSVFile(ApiController controller)
    {
        Dictionary<string, object> dict = new Dictionary<string, object>();
        try
        {
            var httpRequest = HttpContext.Current.Request;
            foreach (string file in httpRequest.Files)
            {
                HttpResponseMessage response = controller.Request.CreateResponse(HttpStatusCode.Created);
