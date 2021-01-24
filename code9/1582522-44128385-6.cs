    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        public Manager Boss {get; set; }
    }
    
    [Serializable]
    public class Manager
    {
        public string Name { get; set; }
        
        public User FavoriteEmployee {get; set; }
    }
    
    public static void TestMethod()
    {
        var userJohn = new User() { Name = "John", Email = "John@john.com" };
        var managerMark = new Manager() { Name = "Mark" };
        
        managerMark.FavoriteEmployee = userJohn;
        userJohn.Boss = managerMark;
        //Save to file
        SerializeObject(@"C:\MyDir\MyFile.txt", userJohn);
        //Read from file
        var userJohnReloaded = DeSerializeObject<User>(@"C:\MyDir\MyFile.txt");
    }
