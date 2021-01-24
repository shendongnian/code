    string xml;
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.OmitXmlDeclaration = true;
    using (MemoryStream ms = new MemoryStream())
      {
        using (XmlWriter writer = XmlWriter.Create(ms, settings))
         {
           XmlSerializerNamespaces names = new XmlSerializerNamespaces();
           names.Add("", "");//add your needed namespaces here
           XmlSerializer cs = new XmlSerializer(typeof(Envelope));
           var myEnv = new Envelope()
            {
             Header = new EnvelopeHeader()
              {
               Security = new Security()
                {
                  UsernameToken = new SecurityUsernameToken()
                   {
                    Username = "",
                    Password = new SecurityUsernameTokenPassword()
                    {
                     Type = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText",//update type to match your case
                     Value = ""
                    }
                   }
                  }
                 },
                 Body = new EnvelopeBody()
                 {
                  Cat = new Cat() { Lives = 7 }
                 }
                };
                cs.Serialize(writer, myEnv, names);
                ms.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(ms);
                xml = sr.ReadToEnd();
              }
         }
