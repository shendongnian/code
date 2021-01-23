    using System;
    using System.Xml;
    using System.Net;
    using System.Text;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                Task task = Task.Factory.StartNew((() =>
                                       {
                                           Console.WriteLine("start");
                                           Thread.Sleep(10000); // your code
                                           Console.WriteLine("end");
                                           if (cts.IsCancellationRequested) return;
                                       }), cts.Token);
                cts.CancelAfter(1000);
                Console.WriteLine("task has been canceled");
                Console.ReadKey();
            }
        }
    }
