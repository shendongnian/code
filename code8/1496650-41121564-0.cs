    using FluentScheduler;
    using StructureMap;
    public class StructureMapJobFactory : IJobFactory
    {
        public IJob GetJobInstance<T>() where T : IJob
        {
            return ObjectFactory.Container.GetInstance<T>();
        }
    }
    
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            // Schedule an IJob to run at an interval
            Schedule<MyJob>().ToRunNow().AndEvery(2).Seconds();
        }
    } 
    
