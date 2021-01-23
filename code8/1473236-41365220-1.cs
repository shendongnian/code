    public class TestCollectionAggregateRoot : IAgregateRoot, 
        IHasObserver<IMongoObserver<TestCollection>>,
        IHasSelector<IMongoSelector<TestCollection>>
    {
        private readonly IMongoSelector<TestCollection> _selector;
        private readonly IMongoObserver<TestCollection> _observer;
        private string _name;
        public TestCollectionAggregateRoot(TestCollection root, IMongoSelector<TestCollection> selector, IMongoObserver<TestCollection> observer)
        {
            _selector = selector;
            _observer = observer;
            Name = root.Name;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    _observer.OnPropertyChanged(x=>x.Name, _name);
                }
            }
        }
        public IMongoObserver<TestCollection> Observer => _observer;
        public IMongoSelector<TestCollection> Selector => _selector;
    }
