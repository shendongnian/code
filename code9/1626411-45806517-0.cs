    public virtual DbSet<RowNumber> RowNumber {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RowNumber>(x => {
                x.HasKey(e => e.Row_Number);
            });
     ...
    }
