    using (var db = new AppDbContext())
    {
        var userUCOs = users.Select(u => u.UCO);
        var existingUserUCOs = new HashSet<int>(db.Users
            .Where(u => userUCOs.Contains(u.UCO))
            .Select(u => u.UCO));
        db.Users.AddRange(Mapper.Map<List<User>>(users
            .Where(u => !existingUserUCOs.Contains(u.UCO))));
        db.SaveChanges();
    }
