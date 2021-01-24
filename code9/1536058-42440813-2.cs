    public class ExternalClass
    {
        public string Whatever { get; set; }
    }
    public class ExternalDocument : IDocument // (only a basic object)
    {
        private readonly ExternalClass _class;
        public ExternalDocument(ExternalClass @class)
        {
            _class = @class;
        }
        public string Name
        {
            get { return _class.Whatever; }
            set { _class.Whatever = value; }
        }
    }
