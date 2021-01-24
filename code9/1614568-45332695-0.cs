    [HttpGet]
    [Route("loaderio-a65421134i3ia3d110vcv0120d1ac14b")]		
    public HttpResponseMessage GetLoaderIoVerification()		
    {		
            var response = Request.CreateResponse(HttpStatusCode.OK);		
            response.Content = new StringContent("loaderio-a65421134i3ia3d110vcv0120d1ac14b", Encoding.UTF8, "text/plain");		
            return response;		
    }
