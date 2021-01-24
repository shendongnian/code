    static class Utility
    {
        public static async Task<bool> TimeConsumingMethodOne(Action<int> progress)
        {
            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(100);
                progress(i);
            }
            return true;
        }
        public static async Task<bool> TimeConsumingMethodTwo(Action<int> progress)
        {
            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(50);
                progress(i);
            }
            return true;
        }
    }
