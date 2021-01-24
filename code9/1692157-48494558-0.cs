    private void OnException(Exception exception)
    {
        Policy.Handle<Exception>()
            .WaitAndRetryForever(retryAttempt => TimeSpan.FromSeconds(5), (ex, timespan) =>
            {
                _logger.Warning($"Unable to connect: {ex.Message}.");
            })
            .Execute(CreateWebsphereQueueConnection);
    }
