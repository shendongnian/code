    /// <summary>
    /// Serialize object in xml format on a string
    /// </summary>
    public static class StringXmlSerializer
    {
        public static string XmlSerialize( object objectInstance )
        {
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.NewLineHandling = NewLineHandling.Entitize;
            var serializer = new XmlSerializer( objectInstance.GetType() );
            var sb = new StringBuilder();
           using( XmlWriter xmlWriter = XmlWriter.Create( sb, ws ) )
               serializer.Serialize( xmlWriter, objectInstance );
            return sb.ToString();
        }
        public static T XmlDeserialize<T>( string objectData )
        {
            return (T)XmlDeserialize( objectData, typeof( T ) );
        }
        public static object XmlDeserialize( string objectData, Type type )
        {
            var serializer = new XmlSerializer( type );
            using( TextReader reader = new StringReader( objectData ) )
                return serializer.Deserialize( reader );
        }
    }
