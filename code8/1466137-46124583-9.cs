    /// <inheritdoc />
    /// <summary>
    /// Represents the collection of files.
    /// </summary>
    public interface ICommonFileCollection : IReadOnlyList<ICommonFile>
    {
        /// <summary>
        /// File Indexer by name
        /// </summary>
        /// <param name="name">File name index</param>
        /// <returns>File with related file name index</returns>
        ICommonFile this[string name] { get; }
        /// <summary>
        /// Gets file by name
        /// </summary>
        /// <param name="name">file name</param>
        /// <returns>File with related file name index</returns>
        ICommonFile GetFile(string name);
        /// <summary>
        /// Gets Files by name
        /// </summary>
        /// <param name="name"></param>>
        /// <returns>Files with related file name index</returns>
        IReadOnlyList<ICommonFile> GetFiles(string name);
    }
