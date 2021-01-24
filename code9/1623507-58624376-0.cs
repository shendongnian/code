    internal static class ValueTaskExtensions
    {
        public static Task WhenAll(this IEnumerable<ValueTask> tasks)
        {
            return Task.WhenAll(tasks.Select(v => v.AsTask()));
        }
    }
