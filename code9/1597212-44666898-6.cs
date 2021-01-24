    class ObservableDictionary<TKey, TValue> : IDictionary, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private Dictionary<TKey, TValue> mDictionary;
		
        //Methods & Properties for IDictionary implementation would defer to mDictionary:
        public void Add(TKey key, TValue value)
        {
            mDictionary.Add(key, value);
            OnCollectionChanged(NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value)
            return;
        }
   
        //Implementation of INotifyCollectionChanged:
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
		{
            //event fire implementation
        }
		
        //Implementation of INotifyProperyChanged:
        public event ProperyChangedEventHandler ProperyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs args)
		{
            //event fire implementation
        }
    }
