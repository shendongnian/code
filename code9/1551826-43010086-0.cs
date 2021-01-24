    public class MyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                    {
                        HttpResponseMessage response = task.Result;
                        IOwinContext owinContext = request.GetOwinContext();
                        // do something with the response and owinContext
                        return response;
                    },
                cancellationToken);
        }
    }
