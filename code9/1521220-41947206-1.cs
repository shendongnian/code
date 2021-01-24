    using System.IO;        
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace GenericTesting
    {                                   
      static class ExtensionHelper
      { 
        public static string SerializeToXml<T>(this T valueToSerialize)
        {
          dynamic ns = new XmlSerializerNamespaces();
          ns.Add("", "");
          StringWriter sw = new StringWriter();
    
          using (XmlWriter writer = XmlWriter.Create(sw, new XmlWriterSettings { OmitXmlDeclaration = true }))
          {
            dynamic xmler = new XmlSerializer(valueToSerialize.GetType());
            xmler.Serialize(writer, valueToSerialize, ns);
          }
    
          return sw.ToString();
        }
                              
        public static T DeserializeXml<T>(this string xmlToDeserialize)
        {
          dynamic serializer = new XmlSerializer(typeof(T));
    
          using (TextReader reader = new StringReader(xmlToDeserialize))
          {
            return (T)serializer.Deserialize(reader);
          }
        }
      }
    }
