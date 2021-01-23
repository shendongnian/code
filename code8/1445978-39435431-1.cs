    public class MyController : Controller
        {
            private ShoppingDbContext _context;
    
            public MyController(ShoppingDbContext context)
            {
                _context = context;
            }
    }
