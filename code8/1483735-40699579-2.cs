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
        // This works!
        var userDto = MapProperties<UserDto>(user);  
    }
