          public static dynamic ReadXmlFile(string filePath, Type type)
      {
        dynamic rtn = Activator.CreateInstance(type);
        FileStream fs = null;
        try
        {
          XmlSerializer serializer = new XmlSerializer(type);
          fs = new FileStream(filePath, FileMode.Open);
          rtn = serializer.Deserialize(fs);
        }
        catch(Exception e)
        {
        }
        finally
        {
          if(fs != null)
            fs.Close();
        }
        return rtn;
      }
