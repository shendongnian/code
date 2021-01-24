    /// <summary>
    /// Parses and returns the result of the specified string template.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    /// <param name="razorTemplate">The string template.</param>
    /// <param name="model">The model instance.</param>
    /// <param name="cacheName">The name of the template type in the cache or NULL if no caching is desired.</param>
    /// <returns>The string result of the template.</returns>
    public static string Parse<T>(string razorTemplate, T model, string cacheName)
