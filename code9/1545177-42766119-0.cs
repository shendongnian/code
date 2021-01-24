    public class Xyz
    {
        private volatile int count;
    
        public void Reset()
        {
            count = 0;
        }
    
        public void Process()
        {
            count += 10;
        }
    }
