    public async Task Run()
        {
            Console.WriteLine("Main start");
            await getTask1();
            await getTask2();
            Console.WriteLine("Main end");
        }
        public async Task AlternateRun()
        {
            Console.WriteLine("Main start");
            List<Task> task_list = new List<Task>();
            task_list.Add(getTask1());
            task_list.Add(getTask2());
            var task_result = Task.WhenAll(task_list);
            task_result.Wait();
            Console.WriteLine("Main end");
        }
        private async Task getTask1()
        {
            Console.WriteLine("task1 start");
            await Task.Delay(100);
            Console.WriteLine("task1 end");
        }
        private async Task getTask2()
        {
            Console.WriteLine("task2 start");
            await Task.Delay(100);
            Console.WriteLine("task2 end");
        }
