    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false)]
    public class XmlUnknownElementEventHandlerAttribute : System.Attribute
    {
    }
    public static partial class XmlSerializationHelper
    {
        public static T LoadFromXml<T>(this string xmlString, XmlSerializer serial = null)
        {
            serial = serial ?? new XmlSerializer(typeof(T));
            serial.UnknownElement += UnknownXmlElementEventHandler;
            using (StringReader reader = new StringReader(xmlString))
            {
                return (T)serial.Deserialize(reader);
            }
        }
        
        public static void UnknownXmlElementEventHandler(object sender, XmlElementEventArgs e)
        {
            var obj = e.ObjectBeingDeserialized;
            foreach (var method in obj.GetType().BaseTypesAndSelf()
                .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                .Where(m => Attribute.IsDefined(m, typeof(XmlUnknownElementEventHandlerAttribute))))
            {
                method.Invoke(obj, BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { sender, e }, null);
            }
        }
    }
    
    public static class TypeExtensions
    {
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
