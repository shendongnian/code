       /// <summary>
       /// The serialize.
       /// </summary>
       /// <param name="value">
       /// The value.
       /// </param>
       /// <param name="xmlWriterSettings">
       /// The xml writer settings.
       /// </param>
       /// <typeparam name="T">
       /// The object of the type T.
       /// </typeparam>
       /// <returns>
       /// The value in <see cref="string"/> that correspond the xml.
       /// </returns>
       /// <exception cref="ArgumentException">
       /// The value cannot be null.
       /// </exception>
       public static string Serialize<T>(T value, XmlWriterSettings xmlWriterSettings = null)
       {
           if (value == null)
           {
               throw new ArgumentException("value");
           }
 
           var serializer = new XmlSerializer(typeof(T));
 
           var settings = xmlWriterSettings ?? new XmlWriterSettings
           {
               Encoding = new UnicodeEncoding(false, false),
               Indent = false,
               OmitXmlDeclaration = false
           };
 
           using (var textWriter = new StringWriter())
           {
               using (var xmlWriter = XmlWriter.Create(textWriter, settings))
               {
                   serializer.Serialize(xmlWriter, value);
               }
 
               return textWriter.ToString();
           }
       }
    /// <summary>
    /// The deserialize.
    /// </summary>
    /// <param name="xml">
    /// The xml.
    /// </param>
    /// <param name="xmlReaderSettings">
    /// The xml Reader Settings.
    /// </param>
    /// <typeparam name="T">
    /// The object of the type T.
    /// </typeparam>
    /// <returns>
    /// The object of the type <see cref="T"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// The xml value cannot be null.
    /// </exception>
    public static T Deserialize<T>(string xml, XmlReaderSettings xmlReaderSettings = null)
    {
        if (string.IsNullOrEmpty(xml))
        {
            throw new ArgumentException("xml");
        }
     
        var serializer = new XmlSerializer(typeof(T));
     
        var settings = xmlReaderSettings ?? new XmlReaderSettings();
     
        // No settings need modifying here
        using (var textReader = new StringReader(xml))
        {
            using (var xmlReader = XmlReader.Create(textReader, settings))
            {
                return (T)serializer.Deserialize(xmlReader);
            }
        }
    }
