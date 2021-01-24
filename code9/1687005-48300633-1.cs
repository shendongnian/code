            var taskRunner = new TaskBatchRunner(tasks.ToArray());
            taskRunner.TaskCompleted += MyTaskCompleted;
            taskRunner.Run();
            ...
        private void MyTaskCompleted(object sender, Task e)
        {
            System.Diagnostics.Debug.WriteLine($"task {e.Id} completed!");
        }
