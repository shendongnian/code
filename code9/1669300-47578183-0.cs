    interface IResponse {
        void Configure(); // Use custom parameters if necessary
    }
    public async Task<TResponse> HandleResponseAsync<TRequest, TResponse>(TRequest item)  where TResponse : class, new(), IResponse {
        TResponse result = new TResponse();
        result.Configure(...);
    }
