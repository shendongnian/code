    public class UserVM
    {
        public string UserName { get; set; }
        public List<RoleVM> Roles { get; set; }
    }
    public class RoleVM
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
