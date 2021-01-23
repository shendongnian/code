    public interface IProcessor
    {
        void Process(Credentials credentials);
    }
    public class Credentials
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public abstract class SupplierBase : IProcessor
    {
        private void Connect(Credentials credentials)
        {
            //...
        }
        private void Disconnect()
        {
            //...
        }
        public void Process(Credentials credentials)
        {
            Connect(credentials);
            Execute();
            Disconnect();
        }
        protected abstract void Execute();
    }
    public void MySupplier : SupplierBase
    {
        //You can add unique supplier properties here.
        public string SomeProperty { get; set; }
        protected override void Execute()
        {
            //Implementation here
            Console.WriteLine(SomeProperty);
        }
    }
