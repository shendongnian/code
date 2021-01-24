    namespace Mutex_1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Mutex req_mutex = new Mutex(true, "req_mutex");
                String t = string.Empty;
                while (!t.Contains("q"))
                {
                    Console.WriteLine("input: ");
                    t = Console.ReadLine();
                    Console.WriteLine("waiting for req_mutex");
                    req_mutex.WaitOne(); // not required for first click
                    Console.WriteLine("releasing req_mutex");
                    req_mutex.ReleaseMutex();
                }
                Console.ReadLine();
            }
        }
    }
    namespace Mutex_2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Mutex req_mutex = null;
                bool waitingForReqMutexCreation = true;
                while (waitingForReqMutexCreation)
                {
                    try
                    {
                        req_mutex = Mutex.OpenExisting("req_mutex");
                        waitingForReqMutexCreation = false;
                    }
                    catch (WaitHandleCannotBeOpenedException)
                    {
                        Console.WriteLine("req_mutex does not exist.");
                        Thread.Sleep(1000);
                    }
                }
                Console.WriteLine("req_mutex found");
                req_mutex.WaitOne(); // wait for new request   *********** problem here *********
                Console.WriteLine("after req_mutex.WaitOne()");
                req_mutex.ReleaseMutex(); // release req mutex for more requests
                Console.ReadLine();
            }
        }
    }
