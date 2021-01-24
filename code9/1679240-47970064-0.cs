    public class FixedQueue<T>
    {
        private ConcurrentQueue<T> m_Queue = new ConcurrentQueue<T>();
        private Int3 m_Limit;
        private Object m_Lock = new Object();
 
        public Int32 Limit
        {
            get { return m_Limit; }
            set { m_Limit = value; }
        }
        public FixedQueue<T>(Int32 limit)
        {
            m_Limit = limit;
        }
        public void Enqueue(T obj)
        {
            m_Queue.Enqueue(obj);
        
            lock (m_Lock)
            {
                T overflow;
                while ((m_Queue.Count > m_Limit) && m_Queue.TryDequeue(out overflow)) ;
            }
        }
    }
