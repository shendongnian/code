    public async Task<User> CreateAsync(User entity)
    {
  
        ctx.User.Add(entity);
        await ctx.SaveChangesAsync();
        await GeneralDB.UpdateLocation(ctx, "user", entity.Location, entity.Id);
        return entity;  
    }
