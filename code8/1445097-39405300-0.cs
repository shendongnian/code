    public class ClassLibraryOneDbContext : DbContext
    {
        public ClassLibraryOneDbContext()
            : base("DatabaseOne")
        {
        }
    }
..
    public class ClassLibraryTwoDbContext : DbContext
    {
        public ClassLibraryTwoDbContext()
            : base("DatabaseTwo")
        {
        }
    }
