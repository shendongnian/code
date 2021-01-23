         public static dynamic ReadXmlFile(string filePath, Type type)
     {
        TextWriter writer = null;
        try
        {
          XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
          ns.Add("", "");
          XmlSerializer serializer = new XmlSerializer(type);
          writer = new StreamWriter(filePath);
          serializer.Serialize(writer, data, ns);
        }
        catch(Exception e)
        {
        }
        finally
        {
          if(writer != null)
            writer.Close();
        }
       }
