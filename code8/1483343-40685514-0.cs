    private readonly IDataProtector _dataProtector;
   
    public DiscussionController(IDataProtectionProvider dataProtectionProvider)
    {
        _dataProtector = dataProtectionProvider.CreateProtector(nameof(SessionMiddleware));
    }
    public ViewResult Index()
    {       
       string cookieValue;
       HttpContext.Request.Cookies.TryGetValue(".AspNetCore.Session", out cookieValue);
       var protectedData = Convert.FromBase64String(Pad(cookieValue));
       var unprotectedData = _dataProtector.Unprotect(protectedData);
       string humanReadableData = System.Text.Encoding.UTF8.GetString(unprotectedData);
    }
