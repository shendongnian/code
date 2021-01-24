    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    string filepath = @"c:\temp\users.xml";
    var usersToStore = new List<User>
    {
         new User { Name = "John Doe", Age = 42 },
         new User { Name = "Jane Doe", Age = 29 }
    };
    using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
    {
        XmlSerializer serializer = new XmlSerializer(usersToStore.GetType());
        serializer.Serialize(fs, usersToStore);
    }
     var retrievedUsers = new List<User>();
     using (FileStream fs2 = new FileStream(filepath, FileMode.Open))
     {
         XmlSerializer serializer = new XmlSerializer(usersToStore.GetType());
         retrievedUsers = serializer.Deserialize(fs2) as List<User>;
     }
