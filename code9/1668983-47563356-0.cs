    public static class ThisWorks
    {
        public static System.Runtime.CompilerServices.TaskAwaiter GetAwaiter(this Int32 millisecondsDue)
        {
            return TimeSpan.FromMilliseconds(millisecondsDue).GetAwaiter();
        }
        private static System.Runtime.CompilerServices.TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
        {
            return Task.Delay(timeSpan).GetAwaiter();
        }
    }
