        private delegate void TaskBody();
        private class TaskManager
        {
            private ConcurrentQueue<TaskBody>
                TaskBodyQueue = new ConcurrentQueue<TaskBody>();
            private readonly SemaphoreSlim 
                TaskBodySemaphoreSlim = new SemaphoreSlim(1, 1);
            public async void Enqueue(TaskBody body)
            {
                TaskBodyQueue.Enqueue(body);
                await TaskBodySemaphoreSlim.WaitAsync();
                Console.WriteLine($"Cycle ...");
                if (TaskBodyQueue.TryDequeue(out body) == false) {
                    throw new InvalidProgramException($"TaskBodyQueue is empty!");
                }
                body();
                Console.WriteLine($"Cycle ... done ({TaskBodyQueue.Count} left)");
                TaskBodySemaphoreSlim.Release();
            }
        }
        public static void Main(string[] args)
        {
            var random = new Random();
            var tm = new TaskManager();
            Parallel.ForEach(Enumerable.Range(0, 30), async number => {
                await Task.Delay(100 * number);
                tm.Enqueue(delegate {
                    Console.WriteLine($"Print {number}");
                });
            });
            Task
                .Delay(4000)
                .Wait();
            WaitFor(action: "exit");
        }
        public static void WaitFor(ConsoleKey consoleKey = ConsoleKey.Escape, string action = "continue")
        {
            Console.Write($"Press {consoleKey} to {action} ...");
            var consoleKeyInfo = default(ConsoleKeyInfo);
            do {
                consoleKeyInfo = Console.ReadKey(true);
            }
            while (Equals(consoleKeyInfo.Key, consoleKey) == false);
            Console.WriteLine();
        }
