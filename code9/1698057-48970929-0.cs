    public virtual Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Execute());
    }
    private HttpResponseMessage Execute()
    {
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        try
        {
                ArraySegment<byte> segment = Serialize();
                response.Content = new ByteArrayContent(segment.Array, segment.Offset, segment.Count);
                MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
                contentType.CharSet = _encoding.WebName;
                response.Content.Headers.ContentType = contentType;
                response.RequestMessage = _dependencies.Request;
            }
            catch
            {
                response.Dispose();
                throw;
            }
            return response;
        }
