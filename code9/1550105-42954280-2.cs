    public class TaskDemo
    {
        bool taskRunning = false;
        Action beginTask = () =>
        {
            Console.WriteLine("Method start");
            Thread.Sleep(1000);
        };
        public void RunTask()
        {
            if (!taskRunning)
            {
                Task myTask = Task.Factory.StartNew(() =>
                    {
                        taskRunning = true;
                        beginTask();
                    }).ContinueWith((t) => taskRunning = false);
            }
        }
    }
