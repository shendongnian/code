    public class MyConroller : Controller
    {
        private readonly MyDbContext _context;
        public MyConroller(MyDbContext ctx)
        {
            _context = ctx;
        }
    }
