    }
    public class Basic : IBasic
    {
    }
    public class AnotherBasic : Basic
    {
    }
    public interface IWorker<in TBasic>
    {
        void Run(TBasic basic);
    }
    public class SimpleWorker : IWorker<IBasic>
    {
        public void Run(IBasic basic)
        {
            throw new System.NotImplementedException();
        }
    }
    public class Worker : IWorker<Basic>
    {
        public void Run(Basic basic)
        {
            throw new System.NotImplementedException();
        }
    }
    public class AnotherWorker : IWorker<AnotherBasic>
    {
        public void Run(AnotherBasic basic)
        {
            throw new System.NotImplementedException();
        }
    }
    public class Final
    {
        public void Test()
        {
            List<IWorker<AnotherBasic>> workers = new List<IWorker<AnotherBasic>>
            {
                new SimpleWorker(),
                new Worker(),
                new AnotherWorker()
            };
        }
    }
