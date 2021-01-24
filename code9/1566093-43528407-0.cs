    public class ContextHelper
    {
        private HttpContext _context;
        public ContextHelper(HttpContext context)
        {
            _context = context;
        }
        public void DoStuff()
        {
            DoOtherStuffWith(_context);
        }
    }
