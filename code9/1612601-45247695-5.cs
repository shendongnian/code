    static class Utility
    {
        public static bool TimeConsumingMethodOne(IProgress<int> progress)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
                progress.Report(i);
            }
            return true;
        }
        public static bool TimeConsumingMethodTwo(IProgress<int> progress)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(50);
                progress.Report(i);
            }
            return true;
        }
    }
