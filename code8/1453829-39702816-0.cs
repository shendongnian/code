    private readonly Object _syncRoot = new Object();
    public IdGenerator ClientIdGenerator
    {
        get
        {
            if (clientIdGenerator == null)
            {
                lock (_syncRoot)
                {
                    if (clientIdGenerator == null)
                    {
                        clientIdGenerator = ClientIdPrefix != null ? new IdGenerator(ClientIdPrefix) : new IdGenerator();
                    }
                }
            }
            return clientIdGenerator;
        }
    }
