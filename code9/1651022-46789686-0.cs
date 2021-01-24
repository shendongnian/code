    class T1
    {
        public int Id {get; set;}
        // every T1 has zero or more T2
        public virtual ICollection<T2> T2s {get; set;}
        // other properties
        public int A {get; set;}
        public string B {get; set;}
    }
    class T2
    {
        public int Id {get; set;}
        // every T2 has zero or more T1
        public virtual ICollection<T1> T1s {get; set;}
        // other properties
        public int C {get; set;}
        public string D {get; set;}
    }
    public MyDbContext : DbContext
    {
        public DbSet<T1> T1s {get; set;}
        public DbSet<T2> T2s {get; set;}
    }
