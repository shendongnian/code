    public const string OdataAnnotationAll = "odata.include-annotations=*";
    protected virtual async Task<HttpResponseMessage> RequestCRMAsync(HttpMethod method, string query, string pag, bool annotations)
    {
        HttpRequestMessage request = new HttpRequestMessage(method, query);
        request.Headers.Add("Prefer", "odata.maxpagesize=" + pag);
        if (annotations)
        {
            request.Headers.Add("Prefer", OdataAnnotationAll);
        }
        return await CrmConnector.Client.SendAsync(request);
    }
