    class Program
        {
            static void Main(string[] args)
            {
                var recs = new List<Users> {
        new Users { Name = "Alex", Email = "A", UserID= 1 },
        new Users { Name = "Juan", Email = "B", UserID= 2 },
        new Users { Name = "Peter", Email = "C", UserID= 3 },
        new Users { Name = "Julios", Email = "D", UserID= 4 },
        new Users { Name = "Dennis", Email = "E", UserID= 5 },
        new Users { Name = "Jhon", Email = "F", UserID= 6 },
    };
                var groups = new List<Group> {
        new Group { GroupID= 1, Name = "N1" },
        new Group { GroupID= 2, Name = "N2" },
    };
                var Roles = new List<Roles> {
        new Roles { UserID= 1, RoleID = 1 , GroupID = 1 },
        new Roles { UserID= 1, RoleID = 2 , GroupID = 1},
        new Roles { UserID= 2, RoleID = 3 , GroupID = 2},
    };
    
    
                var userList =
                    from r in recs
                    join c in Roles on r.UserID equals c.UserID into celft
                    from cnew in celft.DefaultIfEmpty()
                    join g in groups on cnew.GroupID equals g.GroupID into gleft
                    select new
                    {
                        UserID = r.UserID,
                        Name = r.Name,
                        Email = r.Email,
                        Roles = (from c1 in Roles
                                 where c1.RoleID == cnew.RoleID
                                 select new
                                 {
                                     c1.RoleID,
                                     Grupo = (from g1 in groups
                                              where g1.GroupID == c1.GroupID
                                              select new
                                              {
                                                  g1.GroupID,
                                                  g1.Name
                                              }).ToList(),
                                 }).ToList(),
                    };
    
                foreach (var item in userList)
                {
                    Console.WriteLine(string.Format("{0} {1} {2} {3}", item.UserID, item.Name, item.Email));
                }
                Console.ReadLine();
            }
        }
    
        class Users
        {
            public int UserID;
            public string Name;
            public string Email;
        }
    
        class Roles
        {
            public int UserID;
            public int RoleID;
            public int GroupID;
        }
    
        class Group
        {
            public int GroupID;
            public string Name;
        }
