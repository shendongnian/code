    public class WeightedSemaphore
    {
        public WeightedSemaphore(int totalWeight)
        {
            currentWeight = TotalWeight = totalWeight;
        }
        private ManualResetEvent signal = new ManualResetEvent(false);
        private int currentWeight;
        public int TotalWeight { get; }
        public int CurrentWeight { get { lock (signal) return currentWeight; } }
        public void Wait(int weight)
        {
            while (true)
            {
                lock (signal)
                {
                    if (currentWeight >= weight)
                    {
                        currentWeight -= weight;
                        return;
                    }
                }
                signal.Reset();
                signal.WaitOne();
            }
        }
        public void Release(int weight)
        {
            lock (signal)
            {
                currentWeight += weight;
                signal.Set();
            }
        }
    }
