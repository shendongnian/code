    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleDto Role{ get; set; }
    }
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
