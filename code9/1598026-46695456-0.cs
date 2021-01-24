    public class InefficientEvent
    {
        private volatile int state = 0;
        
        public Set()
        {
            state = 1;
        }
        
        public InefficientWait()
        {
            while (state != 1)
            {
            }
        }
    }
