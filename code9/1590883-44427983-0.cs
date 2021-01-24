    public MyDbContext(DbContextOptions options, int timeout): base(options)
       {
           Timeout = timeout;
           this.Database.SetCommandTimeout(Timeout);
       }
