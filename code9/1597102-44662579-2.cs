    public class User
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public List<Friend> Friends { set; get; }
    }
    public class Friend
    {
        public string NickName { set; get; }
        public string FirstMetLocation { set; get; }
    }
