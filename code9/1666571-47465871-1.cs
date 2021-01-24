    protected IHubContext<CRUDServiceHubBase<TDTO>> _context;
    public CRUDServiceHubBase(IHubContext<CRUDServiceHubBase<TDTO>> context)
    {
        this._context = context;
    }
    
    public Task Create(TDTO entityDTO)
    {
        return this._context.Clients.All.InvokeAsync(CreateEventName, entityDTO);
    }
