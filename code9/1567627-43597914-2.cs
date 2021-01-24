    public partial class FooContext : DbContext
    {
        //has "MyAssembly.Blog" type
        public virtual DbSet<Blog> Blog { get; set; }
    }        
