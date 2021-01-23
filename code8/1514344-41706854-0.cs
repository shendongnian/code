    public class ContentHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>((responseToCompleteTask) =>
            {
                HttpResponseMessage response = responseToCompleteTask.Result;
                var YourContent = response.Content.ReadAsStreamAsync().Result;
                return response;
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
