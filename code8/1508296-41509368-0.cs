    public DbSet<Log> Logs { get; set; }
    IDbSet<Log> IUnitOfWork.Logs
    {
        get { return Logs; }
    }
