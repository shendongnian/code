    /// <inheritdoc />
    public void Configure(MvcDataAnnotationsLocalizationOptions options)
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }
        options.DataAnnotationLocalizerProvider = (modelType, stringLocalizerFactory) =>
            stringLocalizerFactory.Create(modelType);
    }
