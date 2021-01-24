    using System;
    using System.Threading;
    using System.Threading.Tasks;
     
    namespace ParallelFor
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using C# For Loop \n");
     
            for(int i=0; i <=10; i++){
                Console.WriteLine("i = {0}, thread = {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
     
            Console.WriteLine("\nUsing Parallel.For \n");
     
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("i = {0}, thread = {1}", i,
                Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
               
            Console.ReadLine();
        }
    }
    }`
