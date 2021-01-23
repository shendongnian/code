        public class AsyncManualResetEvent<T>
    {
        private volatile TaskCompletionSource<T> m_tcs = new TaskCompletionSource<T>();
        public Task<T> WaitAsync() { return m_tcs.Task; }
        public void Set(T TResult) { m_tcs.TrySetResult(TResult); }
        public bool IsReset => !m_tcs.Task.IsCompleted;
        public void Reset()
        {
            while (true)
            {
                var tcs = m_tcs;
                if (!tcs.Task.IsCompleted ||
                    Interlocked.CompareExchange(ref m_tcs, new TaskCompletionSource<T>(), tcs) == tcs)
                    return;
            }
        }
    }
