    class Program
    {
        static void Main(string[] args)
        {
           (new Test()).Main();
           Console.ReadKey();
        }
    }
    public class Test
    {
        async Task Callback()
        {
            Console.WriteLine("I'm in callback");
        }
        async Task DoSomething(Func<Task> callback)
        {
            Console.WriteLine("I'm in DoSomething");
            await callback();
        }
        public async void Main()
        {
            Console.WriteLine("I'm in Main");
            await DoSomething(Callback);
            Console.WriteLine("Execution completed");
        }
    }
