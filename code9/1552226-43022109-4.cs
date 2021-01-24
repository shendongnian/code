    /// <summary>
    /// Publish the message to subscribers.
    /// </summary>
    /// <param name="message">The message to publish.</param>
    /// <param name="options">The options for the publish.</param>
    Task Publish(object message, PublishOptions options);
