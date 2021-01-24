    public class ExternalClass
    {
        public string Whatever { get; set; }
    }
    public class ExternalContainer : IContainer
    {
        private readonly List<IComponent> _components;
        public ExternalContainer(ExternalClass @class)
        {
            _components = new List<IComponent> {new ExternalDocument(@class)};
        }
        public IList<IComponent> Components
        {
            get { return _components; }
        }
    }
    public class ExternalDocument : IDocument
    {
        private readonly ExternalClass _class;
        public ExternalDocument(ExternalClass @class)
        {
            _class = @class;
        }
        public string Name // just like 1st example
        {
            get { return _class.Whatever; }
            set { _class.Whatever = value; }
        }
    }
