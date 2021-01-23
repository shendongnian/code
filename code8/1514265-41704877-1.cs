        public class EncryptHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>((responseToCompleteTask) =>
            {
                HttpResponseMessage response = responseToCompleteTask.Result;
                    response.Content = new EncryptContent(response.Content);
                return response;
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
