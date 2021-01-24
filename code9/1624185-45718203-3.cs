    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication2
    {
        class Test
        {
            static void Main()
            {
                MyAsyncMethod().Wait();
                Console.ReadLine();
            }
            [ThreadStatic]
            static int MyContext = 666;
            static async Task MyAsyncMethod()
            {
                MyContext = 555;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + MyContext);
                using (var client = new HttpClient())
                {
                    var html = await client.GetStringAsync("http://google.com");
                }
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + MyContext);
            }
        }
    }
