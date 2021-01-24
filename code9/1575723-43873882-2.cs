    public static class SerializerCache<T> {
       public static readonly XmlSerializer Instance = new XmlSerializer(
           typeof(List<T>), new XmlRootAttribute(typeof(T).Name + "List"));
    }
    
    public static class XMLHelper {
    
        public static List<T> ParseXML<T>(this string @this) where T : class {
            XmlSerializer serializer = SerializerCache<T>.Instance;
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(@this));
    
            if(!string.IsNullorEmpty(@this) && (serializer != null) && (memStream != null)) {
                return serializer.Deserialize(memStream) as List<T>;
            }
            else {
                return null;
            }
        }
    }
