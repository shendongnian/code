    public static class MassTransitExtMethods
    {
        private const string ClientTimeoutHeaderKey = "__ClientTimeout__";
        public static IRequestClient<TRequest, TResponse> CreateRequestClientWithTimeoutHeader<TRequest, TResponse>
        (
            this IBus bus,
            Uri address,
            TimeSpan timeout,
            TimeSpan? ttl = default(TimeSpan?), 
            Action<SendContext<TRequest>> callback = null
        )
            where TRequest : class
            where TResponse : class
        {
            return
                bus
                .CreateRequestClient<TRequest, TResponse>
                (
                    address,
                    timeout,
                    ttl,
                    context =>
                    {
                        context
                        .Headers
                        .Set
                        (
                            ClientTimeoutHeaderKey,
                            timeout.TotalSeconds.ToString(CultureInfo.InvariantCulture)
                        );
                        callback?.Invoke(context);
                    }
                );
        }
        public static TimeSpan? GetClientTimeout(this ConsumeContext consumeContext)
        {
            string headerValue =
                consumeContext
                .Headers
                .Get<string>(ClientTimeoutHeaderKey);
            if (string.IsNullOrEmpty(headerValue))
            {
                return null;
            }
            double timeoutInSeconds;
            if (double.TryParse(headerValue, NumberStyles.Any, CultureInfo.InvariantCulture, out timeoutInSeconds))
            {
                return TimeSpan.FromSeconds(timeoutInSeconds);
            }
            return null;
        }
    }
