    using System;
    using System.Threading.Tasks;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                try
                {
                    DoSomething().Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
    
                Console.WriteLine("DoSomething completed");
            }
            
            public static async Task DoSomething()
            {
                await Task.Factory.StartNew(() =>
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Doing Something");
                    // throw new Exception("Something wen't wrong");
                }).ContinueWith(task =>
                {
                    Console.WriteLine(task.Exception.InnerException.Message);
                }, TaskContinuationOptions.OnlyOnFaulted);
            }
        }
    }
