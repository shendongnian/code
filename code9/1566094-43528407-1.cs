    public class ContextHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        public ContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void DoStuff()
        {
            DoOtherStuffWith(_httpContextAccessor.HttpContext);
        }
    }
