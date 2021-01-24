    using (var ctx = new myDbContext())
    {
        var user = ctx.Users.FirstOrDefault(x => x.UserID == userId);
        RemoveEntityAndAllRelations controller = new RemoveUserAndAllRelations();
        controller.SetContext(ctx);
        controller.RemoveChildren(user);
        ctx.Core_Users.Remove(user);
        ctx.SaveChanges();
    }
