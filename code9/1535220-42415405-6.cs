        public Task task = new Task(DoSomething);
        private static void DoSomething()
        {
            Thread.Sleep(10000);
        }
        private void Draw()
        {
            //if tab is clicked run the Draw method
            if (task.Status == TaskStatus.Running)
            {
                task.Wait();
                task = new Task(DoSomething);
                task.Start();
            }else if (task.Status == TaskStatus.RanToCompletion)
            {
                task = new Task(DoSomething);
                task.Start();
            }
            else
            {
                task.Start();
            }
        }
