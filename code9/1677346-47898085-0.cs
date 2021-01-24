    var users = new User[]
    {
        new User{ Id = Guid.NewGuid(), FirstName= "Bob", LastName ="b", UserName = "bob" },
        new User{ Id = Guid.NewGuid(), FirstName= "Alice", LastName ="a", UserName = "alice" }
    };
    var roles = new Role[]
    {
        new Role{ Id = Guid.NewGuid(), CreatedBy = users[0].Id, Name = "role1", ReadableId="role1" },
        new Role{ Id = Guid.NewGuid(), CreatedBy = users[0].Id, Name = "role2", ReadableId="role2" }
    };
    _context.Users.AddRange(users);
    _context.Roles.AddRange(roles);
    _context.SaveChanges();
    var userroles = new UserRole[]
    {
        new UserRole{ User = users[0], Role = roles[0] }, 
        new UserRole{ User = users[0], Role = roles[1] }, //bob is assigned 2 roles
        new UserRole{ User = users[1], Role = roles[1] }, 
    };
