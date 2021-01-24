    public static class EnumerableOnceExt {
        public static EnumerableOnce<IEnumerable<T>, T> EnumerableOnce<T>(this IEnumerable<T> src) => new EnumerableOnce<IEnumerable<T>, T>(src);
    }
    
    public class EnumerableOnce<T, V> : IEnumerable<V>, IDisposable where T : IEnumerable<V> {
        EnumeratorOnce<V> onceEnum;
    
        public EnumerableOnce(T src) {
            onceEnum = new EnumeratorOnce<V>(src.GetEnumerator());
        }
    
        public IEnumerator<V> GetEnumerator() {
            return onceEnum;
        }
    
        IEnumerator IEnumerable.GetEnumerator() {
            return onceEnum;
        }
    
        public void DoSkip(int n) {
            while (n > 0 && onceEnum.MoveNext())
            --n;
        }
    
        public void DoTake(int n) {
            while (n > 0 && onceEnum.MoveNext())
                --n;
        }
    
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
    
        protected virtual void Dispose(bool disposing) {
            Console.WriteLine("EnumerableOnce.Dispose called");
            if (!disposedValue) {
                if (disposing) {
                    onceEnum.ActuallyDispose();
                }
    
                disposedValue = true;
            }
        }
    
        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            Dispose(true);
        }
        #endregion
    }
    
    public class EnumeratorOnce<V> : IEnumerator<V> {
        IEnumerator<V> origEnum;
        
        public EnumeratorOnce(IEnumerator<V> src) {
            origEnum = src;
        }
    
        public V Current => origEnum.Current;
    
        object IEnumerator.Current => origEnum.Current;
    
        public bool MoveNext() => origEnum.MoveNext();
    
        public void Reset() {
            origEnum.Reset();
        }
    
        public void ActuallyDispose() {
            Console.WriteLine("EnumeratorOnce.ActuallyDispose called");
            origEnum.Dispose();
        }
    
        #region IDisposable Support
        protected virtual void Dispose(bool disposing) {
            Console.WriteLine("EnumeratorOnce.Dispose called");
            // don't allow disposing accidentally
        }
    
        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            Dispose(true);
        }
        #endregion
    }
