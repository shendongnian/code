    public class WebsiteSettingsFiller
    {
        //private readonly IHttpContextAccessor _accessor;
        private readonly HttpContext _context;
        public WebsiteSettingsFiller(IHttpContextAccessor accessor)
        {
            //_accessor = accessor;
            _context = accessor.HttpContext;
        }
    }
