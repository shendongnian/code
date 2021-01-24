    public interface IViewModel<T> where T : RealmObject
    {
        T Item { get; set; }
    }
    public class MyObservableCollection<TViewModel, TRealmObject> : IReadOnlyList<TViewModel>, INotifyCollectionChanged
        where TRealmObject : RealmObject
        where TViewModel : IViewModel<TRealmObject>, new()
    {
        private readonly IRealmCollection<TRealmObject> _collection;
        public TViewModel this[int index] => Project(_collection[index]);
        private event PropertyChangedEventHandler _propertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                UpdateCollectionChangedSubscriptionIfNecessary(isSubscribed: true);
                _collectionChanged += value;
            }
            remove
            {
                _collectionChanged -= value;
                UpdateCollectionChangedSubscriptionIfNecessary(isSubscribed: false);
            }
        }
        public MyObservableCollection(IRealmCollection<TRealmObject> collection)
        {
            _collection = collection;
        }
        private TViewModel Project(TRealmObject obj)
        {
            return new TViewModel
            {
                Item = obj
            };
        }
        private void UpdateCollectionChangedSubscriptionIfNecessary(bool isSubscribed)
        {
            if (_collectionChanged == null)
            {
                if (isSubscribed)
                {
                    // Subscribe via _collection
                }
                else
                {
                    // Unsubscribe via _collection
                }
            }
        }
    }
