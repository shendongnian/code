    public interface IService
    {
        void DoSomething();
    }
    public class NullService : IService
    {
        public void DoSomething()
        {
            // Do nothing at all to represent a no-op
        }
    }
    public class MyService : IService
    {
        public void DoSomething()
        {
            // Do something interesting
            Console.WriteLine("Something was done.");
        }
    }
