    public class ObservableDictionary : IObservableMap<string, object>
    {
        private class ObservableDictionaryChangedEventArgs : IMapChangedEventArgs<string>
        {
            public ObservableDictionaryChangedEventArgs(CollectionChange change, string key)
            {
                this.CollectionChange = change;
                this.Key = key;
            }
            public CollectionChange CollectionChange { get; private set; }
            public string Key { get; private set; }
