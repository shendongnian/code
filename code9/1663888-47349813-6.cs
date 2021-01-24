    public override int SaveChanges()
    {
        GenerateIds();
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync()
    {
        GenerateIds();
        return base.SaveChangesAsync();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{
            this.GenerateIds();
			return base.SaveChangesAsync(cancellationToken);
		}
