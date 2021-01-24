    public static string SerializeToXml<T>(this T valueToSerialize, string namespaceUsed = null)
    {
    	  var ns = new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty, (namespaceUsed != null) ? namespaceUsed : string.Empty) });
    	  using (var sw = new StringWriter())
    	  {
    		using (XmlWriter writer = XmlWriter.Create(sw, new XmlWriterSettings { OmitXmlDeclaration = true }))
    		{
    		  dynamic xmler = new XmlSerializer(typeof(T));
    		  xmler.Serialize(writer, valueToSerialize, ns);
    		}
    
    		return sw.ToString();
    	  }
    }
    public static T DeserializeXml<T>(this string xmlToDeserialize)
    {
      dynamic serializer = new XmlSerializer(typeof(T));
      using (TextReader reader = new StringReader(xmlToDeserialize))
      {
        return (T)serializer.Deserialize(reader);
      }
    }
