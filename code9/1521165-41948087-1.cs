    public class MyLogMessageHandler : DelegatingHandler
    {
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
          // Do logging with request or HttpContext.Current
        }
    }
