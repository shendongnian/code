    public async Task<FunctionResult> TryExecuteAsync(TriggeredFunctionData input, CancellationToken cancellationToken)
    {
        IFunctionInstance instance = _instanceFactory.Create((TTriggerValue)input.TriggerValue, input.ParentId);
        IDelayedException exception = await _executor.TryExecuteAsync(instance, cancellationToken);
        FunctionResult result = exception != null ?
            new FunctionResult(exception.Exception)
            : new FunctionResult(true);
        return result;  
    }
