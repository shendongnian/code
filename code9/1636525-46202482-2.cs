    class Program
    {
        static void Main(string[] args)
        {
            Managed.ManagedClass c = new Managed.ManagedClass();
            // call using Action<int>
            c.TestCallBack(Console.WriteLine);
            // call using ManagedCallbackHandler
            c.TestCallBack2(Console.WriteLine);
            Console.ReadLine();
        }
    }
