    public class AsyncObservableCollection<T> : ObservableCollection<T>, ICloneable
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
        protected override void InsertItem(int index, T item)
        {
            lock (lockList)
            {
                int a = this.Count;
                base.InsertItem(0, item);
            }
        }
        new public object Clone()
        {
            object o;
            lock (lockList)
            {
                o = this.Select(m => m);
            }
            return o;
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
    public static class LINQExtension
    {
        public static IEnumerable<T> ThreadSafeWhere<T>(this AsyncObservableCollection<T> source, Func<T,bool> predicate)
        {
            lock (source.LockList)
            {
                return source.Where(predicate);
            }
        }
        public static T ThreadSafeFirstOrDefault<T>(this AsyncObservableCollection<T> source, Func<T, bool> predicate)
        {
            lock (source.LockList)
            {
                return source.FirstOrDefault(predicate);
            }
        }
        public static T ThreadSafeFirstOrDefault<T>(this AsyncObservableCollection<T> source)
        {
            lock (source.LockList)
            {
                return source.FirstOrDefault();
            }
        }
        public static int ThreadSafeCount<T>(this AsyncObservableCollection<T> source, Func<T, bool> predicate)
        {
            lock (source.LockList)
            {
                return source.Count(predicate);
            }
        }
    }
