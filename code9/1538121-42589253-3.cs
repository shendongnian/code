    public class UserDetails<TUser> where TUser: class
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        // other properties ...
        public string UserId { get; set; }
        public TUser User { get; set; }
    }
