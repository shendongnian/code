    class A
    {
        public int Id {get; set;}
        
        // every A has zero or more Bs:
        public virtual ICollection<B> Bs {get; set;}
        ... //  other properties
    }
    class B
    {
        public int Id {get; set;}
        // every B belongs to zero or more As:
        public virtual ICollection<A> As {get; set;}
        ... //  other properties
    }
    class MyDbContext : DbContext
    {
        public DbSet<A> As {get; set;}
        public DbSet<B> Bs {get; set;}
    } 
