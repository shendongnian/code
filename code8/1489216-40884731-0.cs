    public class Tas_Lock
    {
        int L = 0;
        public void Lock()
        {
            while (0 != Interlocked.CompareExchange(ref L, 1, 0)) { }
        }
        public void Unlock()
        {
            Interlocked.Exchange(ref L, 0);
        }
    }
