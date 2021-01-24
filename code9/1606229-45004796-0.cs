    /// <summary>
    /// Start listening for changes
    /// </summary>
    /// <param name="minimumTime">Time</param>
    /// <param name="minimumDistance">Distance</param>
    /// <param name="includeHeading">Include heading or not</param>
    /// <param name="listenerSettings">Optional settings (iOS only)</param>
    Task<bool> StartListeningAsync(TimeSpan minimumTime, double minimumDistance, bool includeHeading = false, ListenerSettings listenerSettings = null)
