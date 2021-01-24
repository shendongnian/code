    // Create a class to store your object
    public class userdata
    {
        public string name;
        public string birthdate;
    }
    // Instantiate and populate your person object
    var userData = new userdata() { name = txtName.Text, birthdate = txtBirthday.Text };
    // Set up your xml serializer based on your person object
    using (var streamWriter = new System.IO.StreamWriter(@"c:\temp\userData.xml"))
    {
        var xmlSerializer = new System.Xml.Serialization.XmlSerializer(userData.GetType());
        xmlSerializer.Serialize(streamWriter, userData);
    }
    
