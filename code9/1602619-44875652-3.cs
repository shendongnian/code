    public async Task<User> GetByIdAsync(int id)
    {
        User user =  await ctx.User.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        user.Location = await GeneralDB.GetLocation(ctx, "user", id);
        return user;
    }
