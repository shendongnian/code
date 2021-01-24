    var xsn = new XmlSerializerNamespaces();
    xsn.Add("temp", "http://namespaceforxml");
    XmlSerializer s = new XmlSerializer(typeof(Message));
    Message msg = new Message(); 
    // Writing a file requires a TextWriter.
    TextWriter t = new StreamWriter(filename);
    s.Serialize(t,msg,ns);
    t.Close();
