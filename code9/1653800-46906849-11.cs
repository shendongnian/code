    public VarDesignCommController(IHubContext<VarDesignHub> hubcontext)
    {
        HubContext = hubcontext;
        ...
    }
    
    private IHubContext<VarDesignHub> HubContext
    { get; set; }
