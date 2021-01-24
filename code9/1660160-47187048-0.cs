    // Create/Update the roles
    context.Roleses.AddOrUpdate(x => x.RoleName,
                                new Roles { RoleName = "Admin", Weightage = 3 },
                                new Roles { RoleName = "User", Weightage = 1 }
                               );
    // Ensure the roles are in the database
    context.SaveChanges();
    // Fetch the "user" role
    Roles userRole = context.Roleses.Single(r => r.RoleName == "User");
    // Create/Update the user
    context.Userses.AddOrUpdate(x=>x.EmailId,
                                new Users() {
                                             FirstName = "vir",
                                             LastName = "acker",
                                             EmailId = "vir.acker@xyz.com",
                                             Password = password,
                                             Gender = "Male",
                                             Islocked = "false",
                                             CreatedDate = DateTime.Now,
                                             RoleId = userRole.Id
                                            }
                               );
