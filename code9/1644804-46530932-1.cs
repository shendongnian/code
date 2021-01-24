    public MyClass
    {    
        
        public MyClass()
        {
            User user = new User();
            user.FirstName = "User1";
            ...
            WriteUser(user);
            User user1 = ReadUser();
            string username = user1.FirstName;
        }
        void WriteUser(User user)
        {
            string stringToWriteToFile = JsonConvert.SerializeObject(user);
            //Write this string to file
        }
        
        User ReadUser()
        {
            string stringFromFile = ...
            return JsonConvert.DeserializeObject<User>(stringFromFile);
        }
    }
