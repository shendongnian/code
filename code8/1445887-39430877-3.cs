    List<User> Users;
    using (StreamReader Sr = new StreamReader("UserFile.xml"))
    {
        XmlSerializer Deserializer = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("User_Table"));
        Users = (List<User>)Deserializer.Deserialize(Sr);
    }
