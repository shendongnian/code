    foreach (string file in files)
    {
        using (var stream = new FileStream(file, FileMode.Open))
        {
            var settings = new XmlReaderSettings();
            settings.CloseInput = false;
            string version = "";
            using (var xmlReader = XmlReader.Create(stream))
            {
                if (xmlReader.ReadToFollowing("Cars"))
                {
                    version = xmlReader.GetAttribute("version");
                }
                else
                {
                    throw new XmlException("Could not get 'version' attribute of 'Cars' root element!");
                }                    
            }
            stream.Position = 0;
            if (version == "1.00")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(v1.Cars));
                v1.Cars XML = new v1.Cars();
                XML = (v1.Cars)serializer.Deserialize(stream);
            }
            else if (version == "2.00")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(v2.Cars));
                v2.Cars XML = new v2.Cars();
                XML = (v2.Cars)serializer.Deserialize(stream);
            }
        }
    }
