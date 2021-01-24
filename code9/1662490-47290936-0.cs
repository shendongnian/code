    public class ObservableCollectionAsync<T> : ObservableCollection<T>
    {
        public ObservableCollectionAsync()
        {
            BindingOperations.EnableCollectionSynchronization(this, _lock);
        }
        public ObservableCollectionAsync(List<T> list) : base(list)
        {
            BindingOperations.EnableCollectionSynchronization(this, _lock);
        }
        public ObservableCollectionAsync(IEnumerable<T> collection) : base(collection)
        {
            BindingOperations.EnableCollectionSynchronization(this, _lock);
        }
        private readonly SynchronizationContext _synchronizationContext = SynchronizationContext.Current;
        private readonly object _lock = new object();
        private void ExecuteOnSyncContext(Action action)
        {
            if (SynchronizationContext.Current == _synchronizationContext)
            {
                action();
            }
            else
            {
                _synchronizationContext.Send(_ => action(), null);
            }
        }
        protected override void ClearItems()
        {
            ExecuteOnSyncContext(() => base.ClearItems());
        }
        protected override void InsertItem(int index, T item)
        {
            ExecuteOnSyncContext(() => base.InsertItem(index, item));
        }
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            ExecuteOnSyncContext(() => base.MoveItem(oldIndex, newIndex));
        }
        protected override void RemoveItem(int index)
        {
            ExecuteOnSyncContext(() => base.RemoveItem(index));
        }
        protected override void SetItem(int index, T item)
        {
     
            ExecuteOnSyncContext(() => base.SetItem(index, item));
            
        }
        public void RemoveAll(Func<T,bool> predicate)
        {
            CheckReentrancy();
            foreach (var item in this.Where(predicate).ToArray())
            {
                this.Remove(item);
            }
        }
