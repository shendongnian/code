    /// <summary>
    /// Executes the <see cref="P:Microsoft.Data.Sqlite.SqliteCommand.CommandText" /> asynchronously against the database and returns a data reader.
    /// </summary>
    /// <param name="behavior">A description of query's results and its effect on the database.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <remarks>
    /// SQLite does not support asynchronous execution. Use write-ahead logging instead.
    /// </remarks>
    /// <seealso href="http://sqlite.org/wal.html">Write-Ahead Logging</seealso>
    public virtual Task<SqliteDataReader> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken)
    {
      cancellationToken.ThrowIfCancellationRequested();
      return Task.FromResult<SqliteDataReader>(this.ExecuteReader(behavior));
    }
