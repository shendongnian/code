    public class DisposableCollection : IList<IDisposable>, IDisposable
    {
        private List<IDisposable> disposables = new List<IDisposable>();
        #region IList<IDisposable> support
        public int Count
        {
            get
            {
                return ((IList<IDisposable>)disposables).Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return ((IList<IDisposable>)disposables).IsReadOnly;
            }
        }
        public int IndexOf(IDisposable item)
        {
            return ((IList<IDisposable>)disposables).IndexOf(item);
        }
        public void Insert(int index, IDisposable item)
        {
            ((IList<IDisposable>)disposables).Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            ((IList<IDisposable>)disposables).RemoveAt(index);
        }
        public void Add(IDisposable item)
        {
            ((IList<IDisposable>)disposables).Add(item);
        }
        public void Clear()
        {
            ((IList<IDisposable>)disposables).Clear();
        }
        public bool Contains(IDisposable item)
        {
            return ((IList<IDisposable>)disposables).Contains(item);
        }
        public void CopyTo(IDisposable[] array, int arrayIndex)
        {
            ((IList<IDisposable>)disposables).CopyTo(array, arrayIndex);
        }
        public bool Remove(IDisposable item)
        {
            return ((IList<IDisposable>)disposables).Remove(item);
        }
        public IEnumerator<IDisposable> GetEnumerator()
        {
            return ((IList<IDisposable>)disposables).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<IDisposable>)disposables).GetEnumerator();
        }
        public void AddRange(IEnumerable<IDisposable> range)
        {
            disposables.AddRange(range);
        }
        public IDisposable this[int index]
        {
            get
            {
                return ((IList<IDisposable>)disposables)[index];
            }
            set
            {
                ((IList<IDisposable>)disposables)[index] = value;
            }
        }
        #endregion
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach(var disposable in disposables)
                    {
                        disposable.Dispose();
                    }
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }
        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DisposableCollection() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
 
        #endregion
    }
