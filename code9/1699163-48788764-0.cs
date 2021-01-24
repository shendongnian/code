     MyMessage test = new MyMessage();
     DataTable table = new DataTable();
     table.TableName = "test";
      ...init...
      test.Fields = table;
      using (Stream fs = new FileStream("Test.xml", FileMode.Create))
      {
        XmlTextWriter writer = new XmlTextWriter(fs, Encoding.UTF8);
        writer.Formatting = Formatting.Indented;
        new XmlSerializer(typeof(MyMessage)).Serialize(writer, test);
      }
