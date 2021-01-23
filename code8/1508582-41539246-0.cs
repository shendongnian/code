    public class EmployeeSvc
    {
        private readonly DemoContext _context;
        public EmployeeSvc(DemoContext context)
        {
            _context = context();
        }
        // snip ...
    }
    
    public class CompanySvc
    {
        private readonly DemoContext _context;
        public CompanySvc(DemoContext context)
        {
            _context = context();
        }
        // snip ...
    }
     var context = new DemoContext();
     var employeeSvc = new EmployeeSvc(context);
     var companySvc = new CompanySvc(context);
