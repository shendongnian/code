    class Affair
    {
        public int Id {set; set;}
        // an Affair can be member of many Groups:
        public virtual ICollection<Group> Groups {get; set;}
        ... 
    }
    classs Group
    {
        public int Id {set; set;}
        // a Group can have many Affairs:
        public virtual ICollection<Affair> Affairs {get; set;}
        ... 
    }
    class MyDbContext : DbContext
    {
        public DbSet<Affair> Affairs {get; set;}
        public DbSet<Group> Groups {get; set;}
    }
