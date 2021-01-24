    class Program
    {
        static void Main(string[] args)
        {
            var context = new InstanceContext(new CallbackHandler());
            var client = new MyService(context);
            client.DoSomething("a message");
            Console.ReadLine();
    
        }
    }
    
    
    public class CallbackHandler : IServiceCallback
    {
        public Task SendMessageBack(string message);
        {
            Console.WriteLine(message);
        }
    }
