    public abstract class AbstractService : IService
    {
        protected class Transaction
        {
        }
    }
    public class ServiceA : AbstractService
    {
        public void MethodA()
        {
            var transaction = new Transaction();
        }
        public void MethodB()
        {
            var transaction = new Transaction();
        }
    }
    public class ServiceB
    {
        public void MethodA()
        {
            var transaction = new Transaction(); // cannot create
        }
        public void MethodB()
        {
            var transaction = new Transaction(); // cannot create
        }
    }
    internal interface IService
    {
    }
