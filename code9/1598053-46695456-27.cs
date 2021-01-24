    public class InefficientEvent
    {
        private volatile bool signalled = false;
        
        public Signal()
        {
            signalled = true;
        }
        
        public InefficientWait()
        {
            while (!signalled)
            {
            }
        }
    }
