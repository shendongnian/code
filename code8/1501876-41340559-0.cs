    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    public class SwaggerAccessMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (IsSwagger(request) && !Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Redirect);
                // Redirect to login URL
                string uri = string.Format("{0}://{1}", request.RequestUri.Scheme, request.RequestUri.Authority);    
                response.Headers.Location = new Uri(uri);
                return Task.FromResult(response);
            }
            else
            {
                return base.SendAsync(request, cancellationToken);
            }
        }
    
        private bool IsSwagger(HttpRequestMessage request)
        {
            return request.RequestUri.PathAndQuery.Contains("/swagger");
        }
    }
