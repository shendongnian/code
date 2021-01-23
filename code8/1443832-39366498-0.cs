    #region Explicit Interface Implementations
    /// <summary>
    /// Closes the WebSocket connection, and releases all associated resources.
    /// </summary>
    /// <remarks>
    /// This method closes the connection with <see cref="CloseStatusCode.Away"/>.
    /// </remarks>
    void IDisposable.Dispose ()
    {
      close (new CloseEventArgs (CloseStatusCode.Away), true, true, false);
    }
    #endregion
