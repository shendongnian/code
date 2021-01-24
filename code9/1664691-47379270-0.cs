    int state = 0; // 0 = Look for xref; 1 = look for separator
    string[] simpleSeparators = { " ", ", " };
    string rid = "<unknown>";
    
    System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
    settings.DtdProcessing = System.Xml.DtdProcessing.Ignore;
    using (var reader = System.Xml.XmlReader.Create(xmlStream, settings))
    {
       while (reader.Read())
       {
          if (reader.IsStartElement("xref"))
          {
             rid = reader.GetAttribute("rid");
             if (state % 2 == 0) state++;
          }
          else if ((reader.NodeType == System.Xml.XmlNodeType.Text)
             && (state % 2 == 1) && simpleSeparators.Contains(reader.Value))
          {
             state++;
             if (state > 2)
             {
                Console.WriteLine("Consecutive xref nodes around {0}", rid);
             }
          }
          else if (reader.IsStartElement())
             state = 0;
       }
    }
