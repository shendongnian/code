    using (DbContext dbContext = GetDbContext())
    {
        UserRepository userRepository = new UserRepository(dbContext);
        User user = await userRepository.GetAsync(userId);
        user.Account = null;
        await userRepository.SaveAsync(user);
    }
