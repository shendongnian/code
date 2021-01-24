    public long GetCount(string name, NamespaceManager namespaceManager = null)
    {
        if(namespaceManager == null)
        {
            namespaceManager = NamespaceManager.CreateFromConnectionString(this.queueConfig.ConnectionString);
        }
        return namespaceManager.GetQueue(name).MessageCountDetails.ActiveMessageCount;
    }
