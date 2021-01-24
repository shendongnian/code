    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public List<Organization> Organizations { get; set; } = new List<Organization>();
    }
