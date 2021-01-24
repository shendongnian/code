    public class UndoableQueue<T> // I shouldn't be allowed to name anything, ever.
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly object _lock = new object();
        public void Enqueue(T item)
        {
            lock (_lock)
            {
                _queue.Enqueue(item);
            }
        }
        public bool TryDequeue(Func<T, bool> verify, out T dequeued)
        {
            lock (_lock)
            {
                if (!_queue.Any())
                {
                    dequeued = default(T);
                    return false;
                }
                if (verify(_queue.Peek()))
                {
                    dequeued = _queue.Dequeue();
                    return true;
                }
                dequeued = default(T);
                return false;
            }
        }
    }
