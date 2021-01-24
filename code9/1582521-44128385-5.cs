    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    
    public static void TestMethod()
    {
        var myUser = new User() { Name = "John", Email = "John@john.com" };
        //Save to file
        SerializeObject(@"C:\MyDir\MyFile.txt", myUser);
        //Read from file
        var myUserReloaded = DeSerializeObject<User>(@"C:\MyDir\MyFile.txt");
    }
