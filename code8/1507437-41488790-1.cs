    [XmlRoot(ElementName = "PublisherDatabase", Namespace = "http://www.publictalksoftware.co.uk/msa")]
    public class PublisherData
    {
        private ListDict<string, Publisher> _PublishersDictionary;
        public PublisherData()
        {
            // provide the function to generate a key for a Publisher
            _PublishersDictionary = new ListDict<string,Publisher>( (p) => p.Name  );   
        }
    
        [XmlElement]
        public ListDict<string,Publisher> Publishers
        { 
            get { return _PublishersDictionary; }
        }
        
    
        [XmlIgnore]
        public Dictionary<string, Publisher> PublisherDictionary
        {
            get {return _PublishersDictionary.dict; }
        }
    }
