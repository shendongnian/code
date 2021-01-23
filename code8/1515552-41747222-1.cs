    public interface ICanBeNullDependency
    {
        void DoSomething();
    }
    public class AcutallyDoSomething : ICanBeNullDependency
    {
        public void DoSomething()
        {
             Console.WriteLine("something done");
        }
    }
    public class NullDoSomething : ICanBeNullDependency
    {
        public void DoSomething()
        {
            // Do nothing - this class represents a null
        }
    }
