        public class User
        {
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int Zip { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
    
            // parameterless constructor. There is no need to declare it. 
            public User() { }
            static void Main(string[] args)
            {
                User n = new User();
                n.Fname = "fname";
                n.Lname = "lname";
                n.Address = "address";
                n.City = "city";
                n.State = "state";
                n.Zip = 1;
                n.Phone = "phone";
                n.Email = "email";
                SaveXML.SaveData(n, "xml.xml");
            }
            class SaveXML
            {
                public static void SaveData(object obj, string filename)
                {
                    // initialization of XML serializer.
                    XmlSerializer sr = new XmlSerializer(obj.GetType());
                    // get stream from string
                    TextWriter writer = new StreamWriter(filename);
                    // Serialization 
                    sr.Serialize(writer, obj);
                    writer.Close();
                }
            }
        }
