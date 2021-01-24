    db.CreateTable<Roles>();
    db.CreateTable<Users>();
    
    db.Insert(new Roles { Name = "Role 1" });
    db.Insert(new Roles { Name = "Role 2" });
    
    db.Insert(new Users { Email = "user1@gmail.com", Password = "test", RolesId = 1 });
    db.Insert(new Users { Email = "user2@gmail.com", Password = "test", RolesId = 1 });
    db.Insert(new Users { Email = "user3@gmail.com", Password = "test", RolesId = 2 });
    
    var user1 = db.LoadSelect<Users>(x => x.Id == 1);
    
    user1.PrintDump();
