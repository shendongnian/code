    public class TaskDemo
    {
        private static AutoResetEvent autoReset = new AutoResetEvent(true);
        Action beginTask = () =>
        {
            Console.WriteLine("Method start");
            Thread.Sleep(2000);
        };
        public void RunTask()
        {
            Task myTask = Task.Run(() =>
                {
                    autoReset.WaitOne();
                    beginTask();
                }).ContinueWith(t => autoReset.Set());
        }
    }
