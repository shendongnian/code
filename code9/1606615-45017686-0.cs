    public HttpResponseMessage RedirectAction()
    {
        var response = this.Request.CreateResponse(HttpStatusCode.Redirect);
        response.Headers.Location = new Uri(this.Url.Link("ValidationEmailUser", new { Code = emailToken }));
        return response;
    }
