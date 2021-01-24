    class UsernamePasswordPair
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool HasValue { get; private set; }
    
        public static UsernamePasswordPair Create(string usernameLine, string passwordLine)
        {
            UsernamePasswordPair pair = new UsernamePasswordPair();
            pair.Username = usernameLine?.Split('\t')[1];
            pair.Password = passwordLine?.Split('\t')[1];
            pair.HasValue = !string.IsNullOrEmpty(pair.Username) 
                    && !string.IsNullOrEmpty(pair.Password);
            return pair;
        }
    }
    UsernamePasswordPair p1 = UsernamePasswordPair.Create(UserNameLine, PasswordLine);
    bool hasValue = p1.HasValue; // True!
