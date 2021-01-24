            List<Contact> lstContact = new List<Contact>(){
                new Contact(){ Name="hello", Age=10, Date=new DateTime(2017,03,12), City="test"},
                new Contact(){ Name="hello", Age=10, Date=new DateTime(2017,03,12), City="test"},
                new Contact(){ Name="hello", Age=10, Date=new DateTime(2017,03,12), City="test"},
                new Contact(){ Name="hello", Age=10, Date=new DateTime(2017,03,12), City="test"},
                new Contact(){ Name="hello", Age=10, Date=new DateTime(2017,03,12), City="test"},
                new Contact(){ Name="hello", Age=10, Date=new DateTime(2017,03,12), City="test"},
                new Contact(){ Name="hello", Age=10, Date=new DateTime(2017,03,12), City="test"},
                new Contact(){ Name="hello", Age=10, Date=new DateTime(2017,03,12), City="test"},
            };
            String xml;
            using (MemoryStream str = new MemoryStream())
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Contact>));
                ser.Serialize(str, lstContact);
                xml = Encoding.Default.GetString(str.ToArray());
            }
            List<Contact> lstContact2;
            using (MemoryStream str = new MemoryStream(Encoding.Default.GetBytes(xml)))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Contact>));
                lstContact2 = (List<Contact>)ser.Deserialize(str);
            }
