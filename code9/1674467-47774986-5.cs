    /// <summary>
    /// Tests if a host name is pingable
    /// </summary>
    /// <param name="host">The host name can either be a machine name, such as "java.sun.com", or a textual representation of its IP address (127.0.0.1)</param>
    /// <param name="msTimeout">Timeout in milliseconds</param>
    /// <returns></returns>
    Task<bool> IsReachable(string host, int msTimeout = 5000);
