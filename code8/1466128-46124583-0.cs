    /// <summary>
    /// File with common Parameters including bytes
    /// </summary>
    public interface ICommonFile
    {
        /// <summary>
        /// Stream File
        /// </summary>
        Stream File { get; }
        /// <summary>
        /// Name of the file
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the file name with extension.
        /// </summary>
        string FileName { get; }
        /// <summary>
        /// Gets the file length in bytes.
        /// </summary>
        long Length { get; }
        /// <summary>
        /// Copies the contents of the uploaded file to the <paramref name="target"/> stream.
        /// </summary>
        /// <param name="target">The stream to copy the file contents to.</param>
        void CopyTo(Stream target);
        /// <summary>
        /// Asynchronously copies the contents of the uploaded file to the <paramref name="target"/> stream.
        /// </summary>
        /// <param name="target">The stream to copy the file contents to.</param>
        /// <param name="cancellationToken">Enables cooperative cancellation between threads</param>
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken));
    }
