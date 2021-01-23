    namespace SO
    {
        using System;
        using System.Threading.Tasks;
    
        class Program
        {
            static void Main(string[] args)
            {
                DoSomething().Wait();
                Console.WriteLine("DoSomething completed");
                Console.ReadKey();
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
                    if (task.Status == TaskStatus.Faulted)
                    {
                        // log exception
                        Console.WriteLine(task.Exception.InnerException.Message);
                    }
                    else if (task.Status == TaskStatus.RanToCompletion)
                    {
                        // do continuation work here
                    }
                });
            }
        }
    }
