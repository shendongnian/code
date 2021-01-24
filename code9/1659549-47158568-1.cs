        public static T DeserializeXml<T>(this string str)
        {
            var serializer = new XmlSerializer(typeof(T));
            object result;
            using (TextReader reader = new StringReader(str))
            {
                result = serializer.Deserialize(reader);
            }
            return (T) result;
        }
