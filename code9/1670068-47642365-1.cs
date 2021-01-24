            public static void process (List<Combination> list)
            {
                User myUser = new User(); myUser.Id = list[0].UserId; myUser.Name = list[0].UserName;
                var myroles = new List<Role>(); var r = new Role(); string currentRole = list[0].RoleName;
                var descList = new List<Description>(); var d = new Description();
                
                // All stuff done in a single loop.
                foreach (var v in list)
                {
                    d = new Description() { Id = v.DescriptionId, RoleId = v.RoleId, Name = v.DescriptionName };
                    if (currentRole == v.RoleName)
                    {
                        r = new Role() { Id = v.RoleId, Name = v.RoleName, UserId = v.UserId, Descriptions = descList };                    
                        descList.Add(d);
                    }
                    else
                    {
                        myroles.Add(r);
                        descList = new List<Description>(); descList.Add(d);
                        currentRole = v.RoleName;
                    }
                }
                myroles.Add(r);
                myUser.Roles = myroles;
    
                Console.WriteLine("User: " + myUser.Name);
                foreach (var myUserRole in myUser.Roles)
                {
                    Console.WriteLine("Role: " + myUserRole.Name);
                    foreach (var description in myUserRole.Descriptions)
                    {
                        Console.WriteLine("Description: " + description.Name);
                    }
                }
            }
