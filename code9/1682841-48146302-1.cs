    [HttpGet]
    [Route("Callback")]
    public async Task<HttpResponseMessage> Callback()
    {
        //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Exception());
    
        var resp = new HttpResponseMessage(HttpStatusCode.OK);
        resp.Content = new StringContent("<html><body>Logout success</body></html>", System.Text.Encoding.UTF8, @"text/html");
        return resp;
    }
