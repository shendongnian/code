    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Permission> Permissions{ get; set; }
    }
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public enum Permissions
    {
        Read = 1,
        Update = 2,
        Add = 3,
        Delete = 4 //rest of your roles
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Role> Roles { get; set; }
    }
