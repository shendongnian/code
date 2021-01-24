    public class MediaTypeDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var url = request.RequestUri.ToString();
            
            if (url.Contains("OrderInformation"))
            {
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
