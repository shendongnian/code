    IIdentityProvider _identityProvider;
    public BookingRecordService(IIdentityProvider identityProvider)
    {
    	_identityProvider = identityProvider;
    	
    	var isAuth = _identityProvider.GetPrincipal().Identity.IsAuthenticated;
    }
