    class ExammerContext : DbContext
    {
        public IDbSet<ApplicationUser> ApplicationUsers { get; set; }
        // add other classes/tables here.
        public ExammerContext()
            : base("DefaultConnection")
        {
        }
    }
