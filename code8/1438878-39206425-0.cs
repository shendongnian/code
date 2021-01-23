    IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();
    ContentNegotiationResult result = negotiator.Negotiate(
        typeof(Customer), this.Request, this.Configuration.Formatters);
    var response = new HttpResponseMessage
    {
        StatusCode = HttpStatusCode.OK,
        Content = new ObjectContent<Customer>(customer,
            result.Formatter, result.MediaType)
    };
    return response;
