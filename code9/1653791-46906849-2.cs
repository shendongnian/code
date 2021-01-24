    public VarDesignCommController(IHubContext<VarDesignHub> clients)
    {
        Clients = clients;
        ...
    }
    
    private IHubContext<VarDesignHub> Clients
    {
        get;
        set;
    }
