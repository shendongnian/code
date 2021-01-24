    public interface ISomeInterface<TSomeChild> where TSomeChild: IBaseInterface
    {
        void DoSomething(TSomeChild baseInterface);
    }
    public class SomeClass : ISomeInterface<IChildInterface>
    {
        public void DoSomething(IChildInterface baseInterface)
        {
        }
    }
