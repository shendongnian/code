    public IEnumerable<UserVm> GetUsers(Func<Users, bool> predicate)
    {
          return db.Users.Where(predicate).Select(users=>new UserVm
          {
              Name = users.Name,
              Age = users.Age,
              Location = users.Location
          });
    }
