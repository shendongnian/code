    class Program {
        public static void Main() {
            while (true) {
                var sw = Stopwatch.StartNew();
                var task1 = Task.Run(async () => {                    
                    using (new NamedMutex("foo")) {
                        Console.WriteLine("first before await: " + Thread.CurrentThread.ManagedThreadId);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        Console.WriteLine("first after await: " + Thread.CurrentThread.ManagedThreadId);
                    }
                });
                var task2 = Task.Run(async () => {                    
                    using (new NamedMutex("foo")) {
                        Console.WriteLine("second before await: " + Thread.CurrentThread.ManagedThreadId);
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        Console.WriteLine("second after await: " + Thread.CurrentThread.ManagedThreadId);
                    }
                });
                Task.WaitAll(task1, task2);
                //Assert.IsTrue(sw.Elapsed.TotalSeconds >= 5);
                Console.WriteLine(sw.Elapsed);
            }            
        }
    }
