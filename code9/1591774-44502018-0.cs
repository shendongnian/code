    using (var ctx = new MyContext())
    {
      var users = ctx.Users.Where(u => u.Status != -1);
      var tasks = users.Select(UpdateUserProfilePercentageAsync);
      await Task.WhenAll(tasks);
      await ctx.SaveChangesAsync();
    }
    private async Task UpdateUserProfilePercentageAsync(User user)
    {
      user.ProfilePercentage = await UserAlgorithm.CalculatePercentage(user.Id);
    }
