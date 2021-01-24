    /// <summary>
    /// throws <see cref="ArgumentException"/> exception if string is null or empty.
    /// </summary>
    /// <param name="value">string to check its content.</param>
    /// <param name="name">name of parameter passed.</param>
    public static void StringNotNullOrEmpty([CanBeNull] string value,
        [NotNull] [InvokerParameterName] string name)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Value cannot be null or empty", name);
        }
    }
