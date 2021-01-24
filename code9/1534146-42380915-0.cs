    // Create a class to store your object
    public class userdata
    {
        public string name;
        public string birthdate;
    }
    // Instantiate and populate your person object
    var userData = new userdata();
    userData.name = txtName.Text;
    userData.birthday = txtBirthday.Text;
    // Set up your xml serializer based on your person object
    var xmlserializer = new System.Xml.Serialization.XmlSerializer(userData.GetType());
    var stringWriter = new System.IO.StringWriter();
    var xml = string.Empty;
    using (var writer = System.Xml.XmlWriter.Create(stringWriter))
    {
        xmlserializer.Serialize(writer, userData);
        xml = stringWriter.ToString();
    }
    Response.Write(xml);
