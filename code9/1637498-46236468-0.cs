    class DataModel
    {
        private static readonly Lazy<XmlSerializer> lazySerializer = 
           new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(DataModel)));
        public XmlSerializer Serializer
        {
            get { return lazySerializer.Value; }
        }
    }
    
