    private readonly IGenericService _genericService = new GenericService();
    public IGenericService GenericService
    {
        get{ return _genericService; }
        set{ _genericService = value; }
    }
