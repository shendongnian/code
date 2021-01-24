    public class MyController : Controller
    {
        private readonly IDbContextFactory contextFactory;
        public MyController(IMyContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public Task<IActionResult> GetSomeData(string tenantId)
        {
            var context = contextFactory.Create(tenantId);
            return Ok(await context.Data.Where(...).ToListAsync());
        }
    }
