    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    namespace someNamespace 
    {
        public class PreflightRequestsHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.Headers.Contains("Origin") && request.Method.Method.Equals("OPTIONS"))
                {
                    var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(response);
                    return tsc.Task;
                }
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
