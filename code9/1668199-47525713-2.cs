    public class MyRepository
    {
        private readonly IContext _context;
    
        public MyRepository(IContext context)
        {
           _context = context;
        }
    
        public List<TableName> CheckAccessCodesFor()
        {
            var dbrc = _context.View.ToList();
            return dbrc;
        }
    }
