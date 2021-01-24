    public class Pages
    {
    	private readonly ISearchContext _context;
    	
    	public Pages(ISearchContext context)
    	{
    		_context = context;	
    	}
    
    	private T GetPage<T>() where T : new()
    	{
    		var page = new T();
    		PageFactory.InitElements(_context, page);
    		return page;
    	}
    	public LoginPage Login
    	{
    		get { return GetPage<LoginPage>(); }
    	}
    
    	public RegisterPage Register
    	{ get { return GetPage<RegisterPage>(); } }
    
    	public SearchPage Search
    	{ get { return GetPage<SearchPage>(); } }
    }
