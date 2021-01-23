    public StubTContext : DbContext
    {
       public StubTContex(DbSet<Report> reports)
       {
           Reports = reports;
       }
    }
