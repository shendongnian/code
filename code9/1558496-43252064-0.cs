    /// <summary>
    /// Asynchronously send a request to a single handler
    /// </summary>
    /// <typeparam name="TResponse">Response type</typeparam>
    /// <param name="request">Request object</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>A task that represents the send operation. The task result contains the handler response</returns>
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken));
    /// <summary>
    /// Asynchronously send a request to a single handler without expecting a response
    /// </summary>
    /// <param name="request">Request object</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>A task that represents the send operation.</returns>
    Task Send(IRequest request, CancellationToken cancellationToken = default(CancellationToken));
