    public class RequestFilterHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Task<HttpResponseMessage> responseTask;
            if (IsPostOrPutCall(request))
            {
               responseTask = base.SendAsync(request, cancellationToken).ContinueWith(task => task.Result);
            }
            else
            {                        
               responseTask = base.SendAsync(request, cancellationToken);
            }
        }
        private bool IsPostOrPutCall(HttpRequestMessage request)
        {
          return request.Method == HttpMethod.Post || request.Method == HttpMethod.Put;
        }
    }
    
