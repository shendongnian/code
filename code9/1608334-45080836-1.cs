    public void LoadContacts()
    {
        const string fileName = "Contacts.xml";
        
        var assembly = typeof(MainPage).GetTypeInfo().Assembly;
        
        var path = assembly.GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));
            
        if(path == null)
            throw new Exception("File not found");
            
        using (var stream = assembly.GetManifestResourceStream(path))
        using (var reader = XmlReader.Create(stream))
        {           
            while (reader.Read())
            {
                if (reader.Name.Equals("ID") && (reader.NodeType == XmlNodeType.Element))
                {
                    lstd.Add(reader.ReadElementContentAsString());
                }
            }
        }
        DataContext = this; // better to move this inside the constructor
    }
