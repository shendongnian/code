    public class TestAuthHandler : DelegatingHandler
    {
      protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
      {
        // Set the principal. Whether you set the thread principal
        // is optional but you should really use the request context
        // principal exclusively when checking permissions.
        request.GetRequestContext().Principal = CreatePrincipal();
        // Let the request proceed through the rest of the pipeline.
        return await base.SendAsync(request, cancellationToken);
      }
    }
