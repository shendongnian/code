    public static class Serializer<T> where T : class
    {
        public static void Serialize(string filename, T obj)
        {
            using (TextWriter WriteFileStream = new StreamWriter(filename, false))
            {
                XmlSerializer SerializerObj = new XmlSerializer(typeof(T));
                SerializerObj.Serialize(WriteFileStream, obj);
            }
        }
        public static T Deserialize(string filename)
        {
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer SerializerObj = new XmlSerializer(typeof(T));
                    using (XmlReader reader = new XmlTextReader(fs))
                    {
                        if (SerializerObj.CanDeserialize(reader))
                        {
                            return SerializerObj.Deserialize(reader) as T;
                        }
                    }
                }
            }
            return null;
        }
    }
