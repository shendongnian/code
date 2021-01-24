    using (var context = new MyDbContext())
    {
        var userRepository = new UserRepository(context);
        var users = userRepository.GetAll();
    }
