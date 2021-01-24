    // Create a class to store your object
    public class userdata
    {
        public string name;
        public string birthdate;
    }
    // Instantiate and populate your person object
    var userData = new userdata() { name = txtName.txt, birthdate = txtBirthday.Text };
    // Set up your xml serializer based on your person object
    var xmlSerializer = new System.Xml.Serialization.XmlSerializer(userData.GetType());
    xmlSerializer.Serialize(new System.IO.StreamWriter(@"c:\temp\userData.xml"), userData);
