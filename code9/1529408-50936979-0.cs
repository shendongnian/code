    static class Helper
    {
        public async static Task ExecuteInterval(Action execute, int millisecond, IWorker worker)
        {
            while (worker.Worked)
            {
                execute();
                await Task.Delay(millisecond);
            }
        }
    }
    interface IWorker
    {
        bool Worked { get; }
    }
