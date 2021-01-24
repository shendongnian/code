    class User {
        public string Name { get; set; }
    }
    void NotMagic(User user1, User user2) {
        user1.Name = "A";
        user2.Name = "B";
        Console.WriteLine("user1.Name = " + user1.Name);
        Console.WriteLine("user2.Name = " + user2.Name);
    }
    void Main() {
        User user = new User();
        NotMagic(user, user);
    }
