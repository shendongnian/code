        /// <summary>
        /// Converts given class to XML using xml serialization
        /// </summary>
        /// <typeparam name="T">Type of Class</typeparam>
        /// <param name="classObject">Class to be serialized</param>
        /// <returns>Xml string</returns>
        public static string ToXML<T>(this T classObject) where T : class
        {
            XmlSerializer xmls = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = new UTF8Encoding(false);
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.NewLineChars = Environment.NewLine;
                settings.OmitXmlDeclaration = true;
                settings.ConformanceLevel = ConformanceLevel.Document;
                using (XmlWriter writer = XmlTextWriter.Create(ms, settings))
                {
                    xmls.Serialize(writer, classObject);
                }
    
                string xml = Encoding.UTF8.GetString(ms.ToArray());
                return xml;
            }
        }
    
        /// <summary>
        /// Converts given XML string to class of type T
        /// </summary>
        /// <typeparam name="T">Type to be converted</typeparam>
        /// <param name="XmlData">xml string</param>
        /// <returns>class of Type T</returns>
        public static T ToClass<T>(this string XmlData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T newClass;
            using (XmlTextReader reader = new XmlTextReader(new StringReader(XmlData)))
            {
                //reader.Namespaces = false;
                newClass = (T)serializer.Deserialize(reader);
            }
            return newClass;
        }
    }
