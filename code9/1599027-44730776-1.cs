    //here I'm trying to load the file from the disk but you can do the same by passing a string 
      Response  model;
    
                var xml = File.ReadAllText("file.xml");  
                using (TextReader reader = new StringReader(xml))
                {
                    System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Response));
                    model = (Response)deserializer.Deserialize(reader);
                }   
