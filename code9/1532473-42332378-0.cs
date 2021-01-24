    public class HeadHandler : DelegatingHandler
    {
        private const string Head = "IsHead";
    
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Head)
            {
                request.Method = HttpMethod.Get;
                request.Properties.Add(Head, true);
            }
    
            var response = await base.SendAsync(request, cancellationToken);
    
            object isHead;
            response.RequestMessage.Properties.TryGetValue(Head, out isHead);
    
            if (isHead != null && ((bool)isHead))
            {
                var oldContent = await response.Content.ReadAsByteArrayAsync();
    
                response.Content.Headers.ContentLength = oldContent.Length;
                return response;
            }
    
            return response;
        }
    }
