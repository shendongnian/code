    public async Task<IEnumerable<Image>> GetAll()
    {
        using (var context = new DatabaseContext())
        {
            context.Configuration.LazyLoadingEnabled = false;
            return await context.Images.ToListAsync();
        }
    }
