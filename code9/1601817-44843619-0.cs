        class Program
        {
            static void Main(string[] args)
            {
                Context _context = null;
                string id = "123";
                var results = from users in _context.UserRoles
                    where users.UserId == id
                    join  user in  _context.Users  on users.UserId equals user.Id
                    join role in _context.Roles on users.RoleId  equals role.Id            
                    select new
                    {
                        UserID = user.Id ,
                        UserName = user.UserName,
                        RoleID = role.Id,
                        RoleName = role.Name
                    };
            }
     
        }
        public class Context
        {
            public List<User> Users = new List<User>();
            public List<Role> Roles = new List<Role>();
            public List<UserRole> UserRoles = new List<UserRole>();
        }
        public class UserRole
        {
            public string UserId { get; set; }
            public string RoleId { get; set; }
        }
        public class User {
           public string Id { get; set; }
           public string UserName { get; set; }
           public List<Role> Roles { get; set; }
        }
        public class Role {
           public string Id {get; set; }
           public string Name { get; set; }
        }
