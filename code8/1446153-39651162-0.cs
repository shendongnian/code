    public class MyApplicationPool
    {
        public MyApplicationPool(ApplicationPool appPool, string machineName)
        {
            Name = appPool.Name;
            MachineName = machineName;
            State = appPool.State;
            Cpu = appPool.Cpu;
            QueueLength = appPool.QueueLength;
            ApplicationPool = appPool;
        }
        public string MachineName { get; }
        public string Name { get; }
        public ObjectState State { get; }
        public long QueueLength { get; }
        public ApplicationPoolCpu Cpu { get; }
        public ObjectState Start()
        {
            return ApplicationPool.Start();
        }
        public ObjectState Stop()
        {
            return ApplicationPool.Stop();
        }
        public ObjectState Recycle()
        {
            return ApplicationPool.Recycle();
        }
        private ApplicationPool ApplicationPool { get; }
    }
