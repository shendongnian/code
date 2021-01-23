    public class AsyncObservableCollection<T> : ObservableCollection<T>
    {
        private readonly object lockList = new object();
        public object LockList
        {
            get { return lockList; }
        } 
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var eh = CollectionChanged;
            if (eh != null)
            {
                Dispatcher dispatcher = (from NotifyCollectionChangedEventHandler nh in eh.GetInvocationList()
                                         let dpo = nh.Target as DispatcherObject
                                         where dpo != null
                                         select dpo.Dispatcher).FirstOrDefault();
                if (dispatcher != null && dispatcher.CheckAccess() == false)
                {
                    dispatcher.Invoke(DispatcherPriority.DataBind, (Action)(() => OnCollectionChanged(e)));
                }
                else
                {
                    foreach (NotifyCollectionChangedEventHandler nh in eh.GetInvocationList())
                        nh.Invoke(this, e);
                }
            }
        }
        new public void Remove(T item)
        {
            lock (lockList)
            {
                base.Remove(item);
            }
        }
        new public void Add(T item)
        {
            lock (lockList)
            {
                base.Add(item);
            }
        }
        public void AddByCheckExistence(T item)
        {
            lock (lockList)
            {
                if(!this.Contains(item))
                {
                    base.Add(item);
                }
            }
        }
    }
