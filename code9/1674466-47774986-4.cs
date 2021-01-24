    /// <summary>
    /// Tests if a remote host name is reachable (no http:// or www.)
    /// </summary>
    /// <param name="host">Host name can be a remote IP or URL of website</param>
    /// <param name="port">Port to attempt to check is reachable.</param>
    /// <param name="msTimeout">Timeout in milliseconds.</param>
    /// <returns></returns>
    Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000);
