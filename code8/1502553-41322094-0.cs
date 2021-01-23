    using (var db = new AppDbContext())
    {
        db.Users.AddRange(Mapper.Map<List<User>>(users
            .Where(user => !db.Users.Any(u => u.UCO == user.UCO))));
        db.SaveChanges();
    }
