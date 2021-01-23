    static void Main(string[] args)
    {
        var user = new UserModel
        {
            Name = "User McUserson",
            Age = 30,
            Buddy = new UserModel
            {
                Name = "Buddy McFriendly",
                Age = 28
            }
        };
        // This fails saying that UserModel cannot be converted to UserDto
        var userDto = Cast<UserDto>(user);  
    }
    class UserModel
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public UserModel Buddy { get; set; }
    }
    class UserDto
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public UserDto Buddy { get; set; }
    }
