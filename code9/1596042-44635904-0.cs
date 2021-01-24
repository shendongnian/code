    public static IPropagatorBlock<TInput, TOutput> CreateRetryTransformBlock<TInput, TOutput>(
        Func<TInput, TOutput> transform, int retryCount,
        ITargetBlock<(TInput, Exception)> failureBlock)
    {
        var failedInputs = new Dictionary<TInput, int>();
        TransformManyBlock<TInput, TOutput> resultBlock = null;
        resultBlock = new TransformManyBlock<TInput, TOutput>(
            async input =>
            {
                try
                {
                    return new[] { transform(input) };
                }
                catch (Exception exception)
                {
                    failedInputs.TryGetValue(input, out int count);
                    if (count < retryCount)
                    {
                        failedInputs[input] = count + 1;
                        // ignoring the returned Task, to avoid deadlock
                        _ = resultBlock.SendAsync(input);
                    }
                    else
                    {
                        failedInputs.Remove(input);
                        await failureBlock.SendAsync((input, exception));
                    }
                    return Array.Empty<TOutput>();
                }
            });
        return resultBlock;
    }
