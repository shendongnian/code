    public HttpResponseMessage ReviewAll(string para1, string para2, string para3, int para4) {
        if(some_condition) {
            //...code removed for brevity
            int HTTPResponse = 400;
            var response = Request.CreateResponse((HttpStatusCode)HTTPResponse);
            response.ReasonPhrase = "InvalidID";
            return response;
        } else {
            IEnumerable<xxx.Models.Product> responseBody = //...code removed for brevity
            return Request.CreateResponse(HttpStatusCode.Ok, responseBody);
        }
    }
