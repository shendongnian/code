    /// <summary>
    /// Publish the message to subscribers.
    /// </summary>
    /// <param name="context">The instance of <see cref="IPipelineContext" /> to use for the action.</param>
    /// <param name="message">The message to publish.</param>
    public static Task Publish(this IPipelineContext context, object message)
    {
        Guard.AgainstNull(nameof(context), context);
        Guard.AgainstNull(nameof(message), message);
        return context.Publish(message, new PublishOptions());
    }
