    public void AddShortcut(Shortcut s)
    {
       xDoc.Load(FullPath);
       var rootNode = xDoc.GetElementsByTagName("Shortcuts")[0];
       var nav = rootNode.CreateNavigator();
       var emptyNamepsaces = new XmlSerializerNamespaces(new[] {
           XmlQualifiedName.Empty
       });
       using (var writer = nav.AppendChild())
       {
          var serializer = new XmlSerializer(s.GetType());
          writer.WriteWhitespace("");
          serializer.Serialize(writer, s, emptyNamepsaces);
          writer.Close();
       }            
       xDoc.Save(FullPath);
    }
