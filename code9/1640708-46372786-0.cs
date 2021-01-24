    public class RootObject
    {
        readonly ObservableCollection<SomeClass> _collection = new ObservableCollection<SomeClass>();
        [JsonConverter(typeof(ObservableCollectionConverter<SomeClass>>)]
        public ObservableCollection<SomeClass> { get { return _collection; } }
    }
