    public class UnsupportedContentTypeHandler : DelegatingHandler
    {
        private readonly MediaTypeHeaderValue[] supportedContentTypes =
        {
            new MediaTypeHeaderValue("application/json")
        };
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var contentType = request.Content.Headers.ContentType;
            if (contentType == null || !supportedContentTypes.Contains(contentType))
                return request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            return await base.SendAsync(request, cancellationToken);
        }
    }
