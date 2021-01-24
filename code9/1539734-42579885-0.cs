    // internal class ServiceProvider
    ServiceEntry entry;
    if (_table.TryGetEntry(serviceType, out entry))
    {
        return GetResolveCallSite(entry.Last, callSiteChain);
    }
