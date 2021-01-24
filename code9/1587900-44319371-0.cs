        /// <summary>
        /// Deserialize an object from the given reader which has been positioned at the start of the appropriate element.
        /// </summary>
        /// <typeparam name="T">the type of the object to deserialize</typeparam>
        /// <param name="reader">the reader from which to deserialize the object</param>
        /// <returns>an object instance of type 'T'</returns>
        public static T DeserializeFromXml<T>(XmlReader reader)
        {
            T value = (T)new XmlSerializer(typeof(T), new XmlRootAttribute(reader.Name) { Namespace = reader.NamespaceURI }).Deserialize(reader);
            return value;
        }
