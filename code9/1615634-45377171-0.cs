    Role.Roles.First(x => x.RoleID == 01)
        .UsersInRole.AddRange(
            User.Users.Where(x => x.UserID == 01 || x.UserID == 02));
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool ActiveStatus { get; set; }
        public static List<User> Users = new List<User>
        {
            new User {UserID = 01, Name = "Khurram", Address = "London", ActiveStatus = true},
            new User {UserID = 02, Name = "Sana", Address = "London", ActiveStatus = true},
            new User {UserID = 03, Name = "Richard", Address = "London", ActiveStatus = false},
            new User {UserID = 04, Name = "Tracy", Address = "London", ActiveStatus = true},
            new User {UserID = 05, Name = "Laura", Address = "Manchester", ActiveStatus = true},
            new User {UserID = 06, Name = "James", Address = "London", ActiveStatus = false}
        };
    }
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleTitle { get; set; }
        public List<User> UsersInRole { get; set; }
        public static List<Role> Roles = new List<Role>
        {
            new Role {RoleID = 01, RoleTitle = "Admin"},
            new Role {RoleID = 02, RoleTitle = "Management"},
            new Role {RoleID = 03, RoleTitle = "User"}
        };
    }
