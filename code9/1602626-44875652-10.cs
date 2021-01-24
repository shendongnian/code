    public async Task<User> UpdateAsync(User entity)
    {
        ctx.User.Attach(entity);
        ctx.Entry<User>(entity).State = EntityState.Modified;
        await ctx.SaveChangesAsync();
        await GeneralDB.UpdateLocation(ctx, "user", entity.Location, entity.Id);
        return entity;
    }
