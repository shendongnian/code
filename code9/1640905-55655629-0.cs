    public class RetryHandler : DelegatingHandler
    {
        private readonly TimeSpan timeout;
        public RetryHandler(TimeSpan timeout)
        {
            this.timeout = timeout;
        }
        private async Task<HttpResponseMessage> Delay(
            CancellationToken cancellationToken)
        {
            await Task.Delay(timeout, cancellationToken);
            return null;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            for (; ; )
            {
                cancellationToken.ThrowIfCancellationRequested();
                var delayTask = Delay(cancellationToken);
                var firstCompleted = await Task.WhenAny(
                    base.SendAsync(request, cancellationToken), delayTask);
                if (firstCompleted != delayTask)
                    return await firstCompleted;
            }
        }
    }
