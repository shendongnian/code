    public class FooController : Controller
    {
        private readonly DbContext db;
        public class FooController(DbContext db)
        {
            this.db = db;
        }
