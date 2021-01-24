    public static partial class DataContractJsonSerializerHelper
    {
        public static string SerializeJsonSurrogateCollection<T>(this IEnumerable<T> collection) where T : IHasSerializationSurrogate
        {
            if (collection == null)
                throw new ArgumentNullException();
            var surrogate = collection.Select(i => i == null ? null : i.ToSerializationSurrogate()).ToList();
            var settings = new DataContractJsonSerializerSettings
            {
                EmitTypeInformation = EmitTypeInformation.Never,
                KnownTypes = surrogate.Where(s => s != null).Select(s => s.GetType()).Distinct().ToList(),
            };
            return DataContractJsonSerializerHelper.SerializeJson(surrogate, settings);
        }
        public static string SerializeJson<T>(this T obj, DataContractJsonSerializerSettings settings)
        {
            var type = obj == null ? typeof(T) : obj.GetType();
            var serializer = new DataContractJsonSerializer(type, settings);
            return SerializeJson<T>(obj, serializer);
        }
        public static string SerializeJson<T>(this T obj, DataContractJsonSerializer serializer = null)
        {
            serializer = serializer ?? new DataContractJsonSerializer(obj == null ? typeof(T) : obj.GetType());
            using (var memory = new MemoryStream())
            {
                serializer.WriteObject(memory, obj);
                memory.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memory))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
