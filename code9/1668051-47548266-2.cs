        static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(LoadDataPart);
                t.Name = (i + 1).ToString();
                t.Start();
            }
            Console.Read();
        }
        static void LoadDataPart()
        {
            Console.WriteLine("Before Wait {0}", Thread.CurrentThread.Name);
            semaphore.Wait();
            Console.WriteLine("After Wait {0}", Thread.CurrentThread.Name);
            Thread.Sleep(3000);
            Console.WriteLine("Done {0}", Thread.CurrentThread.Name);
            semaphore.Release(10);//this line must be changed,its allow too much thread coz its called 10 times!
        }
