    public virtual DbSet<A> A{ get; set; }
    public IQueryable<A> GetA()
    {
          return A.AsNoTracking();
    }
