    public class MyDelegatingHandler : DelegatingHandler
    {
        private string _token;
        public MyDelegatingHandler(string token)
        {
            _token = token;
        }
        protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            return base.SendAsync(request, cancellationToken);
        }
    }
