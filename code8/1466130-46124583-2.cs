        /// <inheritdoc />
    /// <summary>
    /// File transferred by HttpProtocol, this is an independent
    /// Asp.net core interface
    /// </summary>
    public interface IFormFile : ICommonFile
    {
        /// <summary>
        /// Gets the raw Content-Type header of the uploaded file.
        /// </summary>
        string ContentType { get; }
        /// <summary>
        /// Gets the raw Content-Disposition header of the uploaded file.
        /// </summary>
        string ContentDisposition { get; }
    }
