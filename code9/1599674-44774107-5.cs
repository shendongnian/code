    class Program
    {
        static void Main(string[] args)
        {
            var context = new InstanceContext(new CallbackHandler());
            var client = new ServiceClient(context);
            client.DoSomething("a message");
            Console.ReadLine();
        }
    }
    
    
    public class CallbackHandler : IServiceCallback
    {
        void IServiceCallback.SendMessageBack(string message)
        {
            Console.WriteLine(message);
        }
    }
