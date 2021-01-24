    // What you are serializing
    var obj = default(object);
    using (var reader = XmlReader.Create("LogRecords.xml"))
    using (var writer = XmlWriter.Create("LogRecords2.xml"))
    {
      // Start the log file
      writer.WriteStartElement("LogRecords");
      while (reader.Read())
      {
        // When you see a record in the original file, copy it to the output
        if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "LogRecord")
        {
          writer.WriteNode(reader.ReadSubtree(), false);
        }
      }
      // Add your additional record(s) to the output
      var serializer = new XmlSerializer(obj.GetType());
      serializer.Serialize(writer, obj);
      // Close the tag
      writer.WriteEndElement();
    }
    // Replace the original file with the new file.
    System.IO.File.Delete("LogRecords.xml");
    System.IO.File.Move("LogRecords2.xml", "LogRecords.xml");
