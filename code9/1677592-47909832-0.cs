    public class NamedPermission
    {
        public string Name { get; set; }
        public Permission Permission { get; set; }
    }
    public class Role
    {
        ...
        public List<NamedPermission> Permissions { get; } = new List<NamedPermission>
        {
            new NamedPermission { Name = "Usermanagement" },
            new NamedPermission { Name = "Appointments" },
            new NamedPermission { Name = "Events" }
        };
    }
