    using (DbContext dbContext = GetDbContext())
    {
        UserRepository userRepository = new UserRepository(dbContext);
        User user = await userRepository.GetAsync(userId);
        Account acc = user.Account;
        dbContext.Entity(acc).State = EntityState.Deleted;
        dbContext.SaveChangesAsync();
    }
