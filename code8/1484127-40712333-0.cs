    var user = context.Users.FirstOrDefault(u => u.UserInfo.Username == username)
                                   ?? new User
                                   {
                                       UserInfo = new UserInfo()
                                       {
                                           FirstName = firstName,
                                           LastName = lastName,
                                           Username = username,
                                           Password = password,
                                           Email = email,
                                           RegisteredOn = registeredOnDate.AddDays(2),
                                           LastTimeLoggedIn = lastDateLoggedOn.AddDays(10),
                                           IsDeleted = isDeleted
                                       }
                                   };
