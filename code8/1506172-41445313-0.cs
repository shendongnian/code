    public abstract class AbstractService
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
