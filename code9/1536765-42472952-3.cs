        public static partial class DataContractSerializerHelper
        {
            public static XDocument SerializeContractToXDocument<T>(this T obj)
            {
                return obj.SerializeContractToXDocument(null);
            }
            public static XDocument SerializeContractToXDocument<T>(this T obj, DataContractSerializer serializer)
            {
                var doc = new XDocument();
                using (var writer = doc.CreateWriter())
                {
                    (serializer ?? new DataContractSerializer(obj.GetType())).WriteObject(writer, obj);
                }
                return doc;
            }
            public static T DeserializeContract<T>(this XDocument doc)
            {
                return doc.DeserializeContract<T>(null);
            }
            public static T DeserializeContract<T>(this XDocument doc, DataContractSerializer serializer)
            {
                if (doc == null)
                    throw new ArgumentNullException();
                using (var reader = doc.CreateReader())
                {
                    return (T)(serializer ?? new DataContractSerializer(typeof(T))).ReadObject(reader);
                }
            }
        }
    Next, prune the undesired elements using [XPATH queries](https://msdn.microsoft.com/en-us/library/bb342747), and then serialize the `XDocument` to a final XML representation.
