    var user = db.Users.Where(x => x.Id == 123).AsEnumerable()
      .Select(x => new User(x) {
        PasswordHash = "",
        PasswordSalt = "",
        SecretDataAsInteger = 0
      }).ToList();
