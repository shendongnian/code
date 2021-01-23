    public int GetMaximumFirstLevelRetries(IBus bus)
    {
        var unicastBus = (UnicastBus)bus;
        var transportConfig = unicastBus.Settings.GetConfigSection<TransportConfig>();
        return transportConfig.MaxRetries;
    }
