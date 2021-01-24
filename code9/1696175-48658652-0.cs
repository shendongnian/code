    class MyOriginalDbContext : DbContext
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<ClassRoom> ClassRooms {get; set;}
        ...
    }
    public MyLimitedContext : IDisposable
    {
        // to be filled in constructor
        private readonly MyOriginalDbcontext dbContext = ...
        private readonly int tenantId = ...
        IQueryable<Student> Students
        {
            get
            {
                return this.dbContext.Students
                    .Where(student => student.tenantId == tenantId);
            }
        }
        IQueryable<Student> Teachers
        {
            get
            {
                return this.dbContext.Teachers
                    .Where(teacher => teacher.tenantId == tenantId);
            }
        }
        ...
