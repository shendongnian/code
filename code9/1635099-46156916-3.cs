    public class User
    {
        public int UserId { get; set; }
        [Index(IsUnique = true)]
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }
