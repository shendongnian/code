    public interface IBasic
    {
    }
    public class Basic : IBasic
    {
    }
    public class AnotherBasic : Basic
    {
    }
    public interface IWorker
    {
        void Run(IBasic basic);
    }
    public interface IWorker<in TBasic> : IWorker where TBasic : IBasic
    {
        void Run(TBasic basic);
    }
    public abstract class Worker<TBasic> : IWorker<TBasic> where TBasic : IBasic
    {
        void IWorker.Run(IBasic basic)
        {
            if (basic is TBasic)
                Run((TBasic)basic);
        }
        public abstract void Run(TBasic basic);
    }
    public class FirstWorker : Worker<Basic>
    {
        public override void Run(Basic basic)
        {
            // ...
        }
    }
    public class SecondWorker : Worker<AnotherBasic>
    {
        public override void Run(AnotherBasic basic)
        {
            // ...
        }
    }
    public void Test()
    {
        List<IWorker> workers = new List<IWorker>
        {
            new FirstWorker(),
            new SecondWorker()
        };
    }
    
