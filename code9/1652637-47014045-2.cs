    public override void SaveChanges()
    {
        GenerateIds();
        return base.SaveChanges();
    }
    public override async Task<int> SaveChangesAsync()
    {
        GenerateIds();
        return await base.SaveChangesAsync();
    }
    public override async Task<int> SaveChangesAsync(System.Threading CancellationToken token)
    {
        GenerateIds();
        return await base.SaveChangesAsync(token);
    }
