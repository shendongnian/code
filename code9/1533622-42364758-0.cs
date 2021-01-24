    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var context = serviceProvider.GetRequiredService<ServicesDbContext>();
        var users = await context.User.ToListAsync();
        return users;
    }
