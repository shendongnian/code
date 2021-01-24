    public class MySerializer : XmlObjectSerializer
    {
  
      public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
      {
        reader.ReadFullStartElement();
        Dictionary<string, string> r = new Dictionary<string, string>();
        while (reader.IsStartElement("property"))
        {
          reader.ReadFullStartElement("property");
          reader.ReadFullStartElement("key");
          string key = reader.ReadContentAsString();
          reader.ReadEndElement();
          reader.ReadFullStartElement("value");
          string value = reader.ReadContentAsString();
          reader.ReadEndElement();
          r.Add(key, value);
  
          reader.ReadEndElement();
          reader.MoveToContent();
        }
        return r;
      }
      public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
      {
        throw new NotImplementedException();
      }
  
      public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
      {
        throw new NotImplementedException();
      }
  
      public override void WriteEndObject(XmlDictionaryWriter writer)
      {
        throw new NotImplementedException();
      }
  
      public override bool IsStartObject(XmlDictionaryReader reader)
      {
        throw new NotImplementedException();
      }
    }
