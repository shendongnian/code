    public class User
    {
        public string User_Code { get; set; }
        public string License { get; set; }
        public User_Rank user_Rank { get; set; }
        public User() { }
        public User(User u) 
        {
            User_Code = u.User_Code;
            License = u.License;
            user_Rank = u.user_Rank;
        }
    }
