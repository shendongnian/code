    class Program
    {
        static AutoResetEvent MyThreadCompletedEvent = new AutoResetEvent(false);
        static async void MyThread()
        {
            Console.WriteLine((await MyClass<ConsoleKeyInfo>.Do(Console.ReadKey)).Key);
            MyThreadCompletedEvent.Set();
        }
        static void Main(string[] args)
        {
            Task.Run(() => MyThread());
            // Do stuff
            // Ensure to wait for MyThread to complete
            MyThreadCompletedEvent.WaitOne();
        }
    }
    public static class MyClass<T>
    {
        public static Task<T> Do(Func<T> Method)
        {
            return Task.Run(Method);
        }
    }
