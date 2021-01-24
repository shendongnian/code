    public class Myclass
    {
        private static long Count;
        public Myclass()
        {
             Interlocked.Increment(ref Count);
        }
    }
