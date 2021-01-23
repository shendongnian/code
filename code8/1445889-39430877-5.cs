    List<User> DeserializedUsers;
    using (StreamReader Sr = new StreamReader("UserFile.xml"))
    {
        XmlSerializer Deserializer = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("User_Table"));
        DeserializedUsers = (List<User>)Deserializer.Deserialize(Sr);
    }
