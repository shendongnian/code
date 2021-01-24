    public Guid TenantId { get { return _userContext.TenantId; } }
    
            public BaseApiController(IMapper mapper, IUserContextDataProvider userContext)
            {
                _mapper = mapper;
                _userContext = userContext;
            }
