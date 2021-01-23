    public class ObservableSortedSet<T> : SortedSet<T>, INotifyCollectionChanged where T : IComparable<T>
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public new void Add(T element)
        {
            base.Add(element);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public override void Clear()
        {
            base.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public new void Remove(T element)
        {
            base.Remove(element);
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
