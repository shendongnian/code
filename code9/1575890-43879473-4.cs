        public static T ConvertNode<T>(XmlNode node)
        {
            using (var reader = new XmlNodeReader(node))
            {
                var ser = new XmlSerializer(typeof(T));
                return (T) ser.Deserialize(reader);
            }
        }
